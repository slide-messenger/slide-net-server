using Npgsql;

namespace Server.SQLServer
{
    public class SQLServer
    {
        private static NpgsqlDataSource? _dataSource;

        public static void Connect(string host, string username, string password, string db)
        {
            var connectionString = $"Host={host};Username={username};Password={password};Database={db}";
            _dataSource = NpgsqlDataSource.Create(connectionString);
        }
        public static async Task<int> ExecuteNonQuery(string query)
        {
            await using var cmd = _dataSource!.CreateCommand(query);
            return await cmd.ExecuteNonQueryAsync();
        }
        public static async Task<NpgsqlDataReader> ExecuteReader(string query)
        {
            await using var cmd = _dataSource!.CreateCommand(query);
            return await cmd.ExecuteReaderAsync();
        }
    }
}
