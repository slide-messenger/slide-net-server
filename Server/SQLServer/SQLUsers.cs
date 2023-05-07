using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Server.SQLServer
{
    public class SQLUsers
    {
        public const string TABLE = "users";

        public static async Task<bool> Create(Entities.User user)
        {
            string query = $"INSERT INTO {TABLE}(first_name, last_name, username, password_hash) VALUES ";
            query += $"('{user.FirstName}', '{user.LastName}', '{user.UserName}', '{user.PasswordHash}');";

            return await SQLServer.ExecuteNonQuery(query) == 1;
        }

        public static async Task<bool> UpdateRemoveState(int id, bool state)
        {
            string query = $"UPDATE {TABLE} SET remove_state = {state} WHERE uid = {id};";

            return await SQLServer.ExecuteNonQuery(query) == 1;
        }

        public static async Task<bool> UpdateName(Entities.User user)
        {
            string query = $"UPDATE {TABLE} SET ";
            query += $"first_name = '{user.FirstName}', ";
            query += $"last_name = '{user.LastName}', ";
            query += $"WHERE uid = {user.UserId};";

            return await SQLServer.ExecuteNonQuery(query) == 1;
        }

        public static async Task<bool> Exists(string username)
        {
            string query;
            if (int.TryParse(username, out int id))
            {
                query = $"SELECT EXISTS (SELECT * FROM {TABLE} WHERE uid={id});";
            }
            else
            {
                query = $"SELECT EXISTS (SELECT * FROM {TABLE} WHERE username='{username}');";
            }

            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                if (await reader.ReadAsync())
                {
                    return reader.GetBoolean(0);
                }
            }

            return false;
        }

        public static async Task<Entities.User?> Get(string username)
        {
            string query;
            if (int.TryParse(username, out int id))
            {
                query = $"SELECT * FROM {TABLE} WHERE uid = {id};";
            }
            else
            {
                query = $"SELECT * FROM {TABLE} WHERE username = '{username}';";
            }

            await using (var reader = await SQLServer.ExecuteReader(query))
            {
                if (await reader.ReadAsync())
                {
                    return new Entities.User
                    (
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetDateTime(5),
                        reader.GetInt32(0),
                        reader.GetBoolean(6)
                    );
                }
            }

            return null;
        }
    }
}
