using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Npgsql;
using Server.Entities;
using System.Reflection.PortableExecutable;

namespace Server.SQLServer
{
    public class SQLUsers
    {
        public const string USER_TABLE = "users";
        public const string AUTH_DATA_TABLE = "auth_data";

        public static async Task<int> Create(User user, string password_hash)
        {
            string query = 
$@"INSERT INTO {USER_TABLE}(first_name, last_name, username) VALUES
    ('{user.FirstName}', '{user.LastName}', '{user.UserName}') RETURNING uid;";
            await using var reader = await SQLServer.ExecuteReader(query);
            int id = 0;
            if (!await reader.ReadAsync())
            {
                return 0;
            }
            id = reader.GetInt32(0);
            query =
$@"INSERT INTO {AUTH_DATA_TABLE}(uid, password_hash) VALUES
	({id}, '{password_hash}');";
            if (await SQLServer.ExecuteNonQuery(query) != 1)
            {
                return 0;
            }
            return id;
        }
        public static async Task<string?> GetPasswordHash(int id)
        {
            string query =
$@"SELECT password_hash 
    FROM {AUTH_DATA_TABLE}
    WHERE uid = {id}";
            await using var reader = await SQLServer.ExecuteReader(query);
            return await reader.ReadAsync() ? reader.GetString(0) : null;
        }
        public static async Task<bool> UpdateRemoveState(int id, bool state)
        {
            string query = 
$@"UPDATE {USER_TABLE}
    SET remove_state = {state}
    WHERE uid = {id};";
            return await SQLServer.ExecuteNonQuery(query) == 1;
        }
        public static async Task<bool> Exists(int id)
        {
            string query = 
$@"SELECT EXISTS
    (SELECT *
        FROM {USER_TABLE}
        WHERE uid = {id});";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }
            return false;
        }
        public static async Task<bool> Exists(string username)
        {
            if (int.TryParse(username, out int id))
            {
                return await Exists(id);
            }
            string query = 
$@"SELECT EXISTS 
    (SELECT *
        FROM {USER_TABLE}
        WHERE username = '{username}');";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return false;
            }
            return reader.GetBoolean(0);
        }
        private static User ReadUser(NpgsqlDataReader reader)
        {
            return new User
            (
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4),
                reader.GetBoolean(5)
            );
        }
        public static async Task<User?> Get(int id)
        {
            string query = 
$@"SELECT * 
    FROM {USER_TABLE} 
    WHERE uid = {id};";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return null;
            }
            return ReadUser(reader);
        }
        public static async Task<User?> Get(string username)
        {
            string query;
            if (int.TryParse(username, out int id))
            {
                return await Get(id);
            }
            query = 
$@"SELECT * 
    FROM {USER_TABLE}
    WHERE username = '{username}';";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (!await reader.ReadAsync())
            {
                return null;
            }
            return ReadUser(reader);
        }
    }
}
