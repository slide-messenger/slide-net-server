using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Net;
using System.Reflection;

namespace Server.SQLServer
{
    public class SQLMessages
    {
        private const string MESSAGE_TABLE = "message";
        private const string CHAT_TABLE = "chat";
        private const string MEMBER_TABLE = "chat_member";
        
        public static async Task<List<Entities.Chat>> GetChats(int uid)
        {
            string query = 
@$"SELECT c.cid, c.first_uid, c.second_uid, c.mid as last_mid, cm.mid AS read_mid, c.chatname
	FROM {CHAT_TABLE} AS c 
		JOIN {MESSAGE_TABLE} AS m 
		ON m.cid = c.cid AND m.mid = c.mid
		
		JOIN {MEMBER_TABLE} AS cm
		ON c.cid = cm.cid AND cm.uid = {uid}
	ORDER BY m.send_at DESC;";
            List<Entities.Chat> result = new ();
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Entities.Chat
                    (
                        reader.GetInt32(1),
                        reader.GetString(5),
                        reader.GetInt32(2),
                        reader.GetInt32(0),
                        reader.GetInt32(3),
                        reader.GetInt32(4)
                    ));
                }
            }

            foreach (var chat in result)
            {
                if (chat.SecondId != 0)
                {
                    var interlocutor = await SQLUsers.Get(uid == chat.FirstId ?
                        chat.SecondId.ToString() : chat.FirstId.ToString());
                    chat.ChatName = (interlocutor is null || interlocutor.RemoveState) ? 
                        "DELETED" : (interlocutor.FirstName + " " + interlocutor.LastName);
                }
            }

            return result;
        }
        public static async Task<bool> ChatExists(int cid)
        {
            string query = 
@$"SELECT EXISTS 
(SELECT * 
    FROM {CHAT_TABLE}
    WHERE cid = {cid});";
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                if (await reader.ReadAsync())
                {
                    return reader.GetBoolean(0);
                }
            }
            return false;
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
        public static async Task<List<Entities.Message>> GetMessages(int uid, int cid)
        {
            string query = 
$@"SELECT * 
    FROM {MESSAGE_TABLE}
	WHERE cid = {cid} AND
		NOT(remove_state);";
            List<Entities.Message> result = new();
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Entities.Message
                    (
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetDateTime(5),
                        reader.GetDateTime(6),
                        reader.GetBoolean(7),
                        reader.GetInt32(0)
                    ));
                }
            }

            foreach(var msg in result)
            {
                var user = await SQLUsers.Get(msg.SenderId.ToString());
                msg.Sender = (user == null || user.RemoveState) ?
                    "DELETED " : (user.FirstName + " " + user.LastName);
            }

            return result;
        }
        public static async Task<bool> Send(Entities.Message m)
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
$@"INSERT INTO {MESSAGE_TABLE}(cid, mid, sid, content) 
	VALUES
	({m.ChatId}, (SELECT mid FROM chat WHERE cid = {m.ChatId}), {m.SenderId}, '{m.Content}');";
            if (await SQLServer.ExecuteNonQuery(query) != 1)
            {
                return false;
            }
            return true;
        }
        public static async Task<bool> CheckForNew(int uid)
        {
            string query =
$@"SELECT EXISTS 
	(SELECT cm.cid
		FROM {MEMBER_TABLE} AS cm
			JOIN {CHAT_TABLE} AS c
			ON cm.cid = c.cid AND
				cm.uid = {uid} AND 
				cm.mid < c.mid);";
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                if (await reader.ReadAsync())
                {
                    return reader.GetBoolean(0);
                }
            }
            return false;
        }
    }
}
