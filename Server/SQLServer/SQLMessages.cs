using Npgsql;
using Server.Entities;

namespace Server.SQLServer
{
    public class SQLMessages
    {
        private const string MESSAGE_TABLE = "message";
        private const string CHAT_TABLE = "chat";
        private const string MEMBER_TABLE = "chat_member";

        private const string CHAT_CREATION_MSG = "created this chat";
        private const string USER_JOINED_MSG = "joined this chat";
        private const string DELETED_USER_NAME = "DELETED";
        private const string SAVED_MESSAGES_NAME = "Saved Messages";
        
        private static async Task<string?> ResolveChatName(int uid, Chat chat)
        {
            switch (chat.Type)
            {
                case ChatType.DirectChat:
                    var secondUser = await SQLUsers.Get(uid == chat.FirstId ?
                    chat.SecondId : chat.FirstId);
                    if (secondUser is null) { return null; }
                    return secondUser.RemoveState ?
                        DELETED_USER_NAME : (secondUser.FirstName + " " + secondUser.LastName);
                case ChatType.SavedMessages:
                    return SAVED_MESSAGES_NAME;
                case ChatType.GroupChat:
                    return chat.Name;
                default:
                    throw new NotImplementedException();
            }
        }
        private static Chat GetChatFromReader(NpgsqlDataReader reader)
        {
            return new Chat
                (
                    reader.GetInt32(0),  // cid
                    (ChatType)reader.GetInt32(1),  // type
                    reader.GetInt32(2),  // first_uid
                    reader.GetInt32(3),  // second_uid
                    reader.GetInt32(4),  // last_mid
                    reader.GetInt32(5),  // read_mid
                    reader.GetString(6),  // name
                    reader.GetDateTime(7)  // created_at
                );
        }
        public static async Task<List<Chat>?> GetChats(int uid)
        {
            string query = 
@$"SELECT c.cid, c.type, c.first_uid, c.second_uid, c.mid as last_mid, cm.mid AS read_mid, c.name, c.created_at
	FROM {CHAT_TABLE} AS c 
		JOIN {MESSAGE_TABLE} AS m 
		ON m.cid = c.cid AND m.mid = c.mid
		
		JOIN {MEMBER_TABLE} AS cm
		ON c.cid = cm.cid AND cm.uid = {uid}
	ORDER BY m.sent_at DESC;";
            List<Chat> result = new ();
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                while (await reader.ReadAsync())
                {
                    result.Add(GetChatFromReader(reader));
                }
            }

            foreach (var chat in result)
            {
                var name = await ResolveChatName(uid, chat);
                if (name is null)
                {
                    return null;
                }
                chat.Name = name;
            }

            return result;
        }
        private static Message GetMessageFromReader(NpgsqlDataReader reader)
        {
            return new Message
                (
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3),
                    reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetDateTime(6),
                    reader.GetBoolean(7)
               );
        }
        public static async Task<List<Message>?> GetMessages(int cid)
        {
            string query =
$@"SELECT * 
    FROM {MESSAGE_TABLE}
	WHERE cid = {cid} AND
		NOT(remove_state);";
            List<Message> result = new();
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                while (await reader.ReadAsync())
                {
                    result.Add(GetMessageFromReader(reader));
                }
            }

            Dictionary<int, User?> cache = new();
            foreach (var msg in result)
            {
                if (!cache.ContainsKey(msg.SenderId))
                {
                    cache[msg.SenderId] = await SQLUsers.Get(msg.SenderId);
                }
                var user = cache[msg.SenderId];
                if (user is null) { return null; }
                msg.Sender = user.RemoveState ?
                    DELETED_USER_NAME : (user.FirstName + " " + user.LastName);
            }

            return result;
        }
        public static async Task<bool> Send(Message m)
        {
            string query =
$@"UPDATE {CHAT_TABLE}
	SET mid = mid + 1
	WHERE cid = {m.ChatId};";
            if (await SQLServer.ExecuteNonQuery(query) != 1)
            {
                return false;
            }
            query =
$@"INSERT INTO {MESSAGE_TABLE}(cid, mid, sid, content, sent_at) 
	VALUES
	({m.ChatId}, (SELECT mid FROM chat WHERE cid = {m.ChatId}), {m.SenderId}, $$ {m.Content} $$, '{m.SentAt:O}');";
            if (await SQLServer.ExecuteNonQuery(query) != 1)
            {
                return false;
            }
            return true;
        }
        private static string GetCheckForNewQuery(int uid, int cid)
        {
            return cid == 0 ?
$@"SELECT EXISTS 
	(SELECT cm.cid
		FROM {MEMBER_TABLE} AS cm
			JOIN {CHAT_TABLE} AS c
			ON cm.cid = c.cid AND
				cm.uid = {uid} AND 
				cm.mid < c.mid);" :
$@"SELECT EXISTS 
	(SELECT cm.cid
		FROM {MEMBER_TABLE} AS cm
			JOIN {CHAT_TABLE} AS c
			ON cm.cid = c.cid AND
                cm.cid = {cid} AND
				cm.uid = {uid} AND 
				cm.mid < c.mid);";
        }
        public static async Task<bool> CheckForNew(int uid, int cid)
        {
            await using var reader = await SQLServer.ExecuteReader(GetCheckForNewQuery(uid, cid));
            if (!await reader.ReadAsync())
            {
                return false;
            }
            return reader.GetBoolean(0);
        }
        public static string GetCreateChatQuery(Chat chat)
        {
            return chat.Type switch
            {
                ChatType.DirectChat or ChatType.SavedMessages =>
$@"INSERT INTO {CHAT_TABLE}(type, first_uid, second_uid)
    VALUES({(int)chat.Type}, {chat.FirstId}, {chat.SecondId}) RETURNING cid;",
                ChatType.GroupChat =>
$@"INSERT INTO {CHAT_TABLE}(type, first_uid, name)
    VALUES({(int)chat.Type}, {chat.FirstId}, '{chat.Name}') RETURNING cid;",
                _ => throw new NotImplementedException(),
            };
        }
        public static string GetAddChatMembersQuery(Chat chat)
        {
            return chat.Type switch
            {
                ChatType.DirectChat =>
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES
    ({chat.ChatId}, {chat.FirstId}),
    ({chat.ChatId}, {chat.SecondId});",
                ChatType.GroupChat or ChatType.SavedMessages =>
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES({chat.ChatId}, {chat.FirstId});",
                _ => throw new NotImplementedException(),
            };
        }
        public static bool CheckAffectedByChatCreationRows(Chat chat, int rowsAffected)
        {
            return chat.Type switch
            {
                ChatType.DirectChat => rowsAffected == 2,
                ChatType.GroupChat or ChatType.SavedMessages => rowsAffected == 1,
                _ => throw new NotImplementedException(),
            };
        }
        public static async Task<int> CreateChat(Chat chat)
        {
            await using var reader = await SQLServer.ExecuteReader(GetCreateChatQuery(chat));
            if (!await reader.ReadAsync())
            {
                return 0;
            }
            chat.ChatId = reader.GetInt32(0);
            if (!CheckAffectedByChatCreationRows(chat, 
                await SQLServer.ExecuteNonQuery(GetAddChatMembersQuery(chat))))
            {
                return 0;
            }
            if (!await Send(new Message(chat.ChatId, chat.FirstId, CHAT_CREATION_MSG, DateTime.UtcNow)))
            {
                return 0;
            }
            return chat.ChatId;
        }
        public static async Task<bool> JoinChat(int uid, int cid)
        {
            string query =
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES ({cid}, {uid});";
            if (!await Send(new Message(cid, uid, USER_JOINED_MSG, DateTime.UtcNow)))
            {
                return false;
            }
            return await SQLServer.ExecuteNonQuery(query) == 1;
        }
        public static async Task<bool> IsUserInChat(int uid, int cid)
        {
            string query =
$@"SELECT EXISTS
    (SELECT 1
        FROM {MEMBER_TABLE}
        WHERE cid = {cid} AND
            uid = {uid});";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return false;
            }
            return reader.GetBoolean(0);
        }
        public static async Task<bool> ChatExists(int cid)
        {
            string query =
@$"SELECT EXISTS 
(SELECT 1 
    FROM {CHAT_TABLE}
    WHERE cid = {cid});";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return false;
            }
            return reader.GetBoolean(0);
        }
        public static async Task<bool> ReadAll(int uid, int cid)
        {
            string query =
$@"UPDATE {MEMBER_TABLE}
	SET mid = 
	(SELECT mid 
	 	FROM chat 
	 	WHERE cid = {cid})
	WHERE cid = {cid} AND
		uid = {uid};";
            return await SQLServer.ExecuteNonQuery(query) == 1;
        }
        public static async Task<ChatType?> GetChatType(int cid)
        {
            string query =
$@"SELECT type
    FROM {CHAT_TABLE}
    WHERE cid = {cid}";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return null;
                
            }
            return (ChatType)reader.GetInt32(0);
        }
        public static async Task<bool> DialogExists(int uid1, int uid2)
        {
            string query =
$@"SELECT EXISTS (
	SELECT 1
		FROM chat
		WHERE type = {(int)ChatType.DirectChat} AND 
			(first_uid = {uid1} AND second_uid = {uid2}) OR
			(first_uid = {uid2} AND second_uid = {uid1})
);";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return false;

            }
            return reader.GetBoolean(0);
        }
    }
}
