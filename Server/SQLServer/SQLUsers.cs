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

        public static async Task<bool> Create(User user, string password_hash)
        {
            string query = 
$@"INSERT INTO {USER_TABLE}(first_name, last_name, username) VALUES
    ('{user.FirstName}', '{user.LastName}', '{user.UserName}') RETURNING uid;";

            await using var reader = await SQLServer.ExecuteReader(query);
            int id = 0;
            if (await reader.ReadAsync())
            {
                id = reader.GetInt32(0);
            }
            else
            {
                return false;
            }

            query =
$@"INSERT INTO {AUTH_DATA_TABLE}(uid, password_hash) VALUES
	({id}, '{password_hash}');";
            return await SQLServer.ExecuteNonQuery(query) == 1;
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
            string query = $"UPDATE {USER_TABLE} SET remove_state = {state} WHERE uid = {id};";

            return await SQLServer.ExecuteNonQuery(query) == 1;
        }
        public static async Task<bool> Exists(int id)
        {
            string query;
            query = $"SELECT EXISTS (SELECT * FROM {USER_TABLE} WHERE uid={id});";

            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }

            return false;
        }
        public static async Task<bool> Exists(string username)
        {
            string query;
            if (int.TryParse(username, out int id))
            {
                query = $"SELECT EXISTS (SELECT * FROM {USER_TABLE} WHERE uid={id});";
            }
            else
            {
                query = $"SELECT EXISTS (SELECT * FROM {USER_TABLE} WHERE username='{username}');";
            }

            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return reader.GetBoolean(0);
            }

            return false;
        }
        public static async Task<User?> Get(int id)
        {
            string query = $"SELECT * FROM {USER_TABLE} WHERE uid = {id};";
            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return new User
                (
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetInt32(0),
                    reader.GetBoolean(5)
                );
            }
            return null;
        }
        public static async Task<User?> Get(string username)
        {
            string query;
            if (int.TryParse(username, out int id))
            {
                query = $"SELECT * FROM {USER_TABLE} WHERE uid = {id};";
            }
            else
            {
                query = $"SELECT * FROM {USER_TABLE} WHERE username = '{username}';";
            }

            await using var reader = await SQLServer.ExecuteReader(query);
            if (await reader.ReadAsync())
            {
                return new User
                (
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetInt32(0),
                    reader.GetBoolean(5)
                );
            }

            return null;
        }
    }
}
