using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Npgsql;
using Server.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Reflection;

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
        
        public static async Task<List<Chat>> GetChats(int uid)
        {
            string query = 
@$"SELECT c.cid, c.first_uid, c.second_uid, c.mid as last_mid, cm.mid AS read_mid, c.chatname
	FROM {CHAT_TABLE} AS c 
		JOIN {MESSAGE_TABLE} AS m 
		ON m.cid = c.cid AND m.mid = c.mid
		
		JOIN {MEMBER_TABLE} AS cm
		ON c.cid = cm.cid AND cm.uid = {uid}
	ORDER BY m.send_at DESC;";
            List<Chat> result = new ();
            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Chat
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
                        chat.SecondId : chat.FirstId);
                    chat.ChatName = (interlocutor is null || interlocutor.RemoveState) ? 
                        DELETED_USER_NAME : (interlocutor.FirstName + " " + interlocutor.LastName);
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
            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
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
        public static async Task<List<Message>> GetMessages(int uid, int cid)
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
                    result.Add(new Message
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

            Dictionary<int, User?> cache = new();
            foreach (var msg in result)
            {
                if (!cache.ContainsKey(msg.SenderId))
                {
                    cache[msg.SenderId] = await SQLUsers.Get(msg.SenderId);
                }
                var user = cache[msg.SenderId];
                msg.Sender = (user == null || user.RemoveState) ?
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
$@"INSERT INTO {MESSAGE_TABLE}(cid, mid, sid, content, send_at) 
	VALUES
	({m.ChatId}, (SELECT mid FROM chat WHERE cid = {m.ChatId}), {m.SenderId}, '{m.Content}', '{m.SendAt:O}');";
            if (await SQLServer.ExecuteNonQuery(query) != 1)
            {
                return false;
            }
            return true;
        }
        public static async Task<bool> CheckForNew(int uid, int cid)
        {
            string query;
            if (cid == 0)
            {
                query =
$@"SELECT EXISTS 
	(SELECT cm.cid
		FROM {MEMBER_TABLE} AS cm
			JOIN {CHAT_TABLE} AS c
			ON cm.cid = c.cid AND
				cm.uid = {uid} AND 
				cm.mid < c.mid);";
            }
            else
            {
                query = 
$@"SELECT EXISTS 
	(SELECT cm.cid
		FROM {MEMBER_TABLE} AS cm
			JOIN {CHAT_TABLE} AS c
			ON cm.cid = c.cid AND
                cm.cid = {cid} AND
				cm.uid = {uid} AND 
				cm.mid < c.mid);";
            }
            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }
            return false;
        }
        public static async Task<int> CreateChat(Chat chat)
        {
            string chat_query = chat.SecondId == 0 ?
$@"INSERT INTO {CHAT_TABLE}(first_uid, chatname)
    VALUES({chat.FirstId}, '{chat.ChatName}') RETURNING cid;" :
$@"INSERT INTO {CHAT_TABLE}(first_uid, second_uid)
    VALUES({chat.FirstId}, {chat.SecondId}) RETURNING cid;";
            await using var reader = await SQLServer.ExecuteReader(chat_query);
            int cid;
            if (await reader.ReadAsync())
            {
                cid = reader.GetInt32(0);
            }
            else
            {
                return 0;
            }
            string cm_query = chat.SecondId == 0 ?
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES({cid}, {chat.FirstId});" :
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES
    ({cid}, {chat.FirstId}),
    ({cid}, {chat.SecondId});";
            int rowAffected = await SQLServer.ExecuteNonQuery(cm_query);
            if (chat.SecondId == 0 && rowAffected != 1 ||
                chat.SecondId != 0 && rowAffected != 2)
            { 
                return 0; 
            }

            if (!await Send(new Message(cid, 0, chat.FirstId, CHAT_CREATION_MSG, DateTime.UtcNow)))
            {
                return 0;
            }

            return cid;
        }
        public static async Task<bool> JoinChat(int uid, int cid)
        {
            string query =
$@"INSERT INTO {MEMBER_TABLE}(cid, uid)
    VALUES ({cid}, {uid});";
            if (!await Send(new Message(cid, 0, uid, USER_JOINED_MSG, DateTime.UtcNow)))
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
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }
            return false;
        }
        public static async Task<bool> IsDialog(int cid)
        {
            string query =
$@"SELECT EXISTS
	(SELECT 1
		FROM {CHAT_TABLE}
		WHERE cid = {cid} AND
	 	second_uid != 0);";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }
            return false;
        }
        public static async Task<bool> IsGroupChat(int cid)
        {
            return !await IsDialog(cid);
        }
    }
}
