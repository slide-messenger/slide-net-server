using Npgsql;

namespace Server.SQLServer
{
    public class SQLServer
    {
        public const string host = "pgdb";
        private const string username = "postgres";
        private const string password = "postgres";
        private const string db = "postgres";
        private static NpgsqlDataSource? _dataSource;

        public static async Task Connect()
        {
            var connectionString = $"Host={host};Username={username};Password={password};Database={db}";
            _dataSource = NpgsqlDataSource.Create(connectionString);

            try
            {
                await ExecuteNonQuery("SELECT 1");
            }
            catch (Exception)
            {
                throw;
            }
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
