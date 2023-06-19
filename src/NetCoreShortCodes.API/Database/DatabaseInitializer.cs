using Dapper;

namespace NetCoreShortCodes.API.Database
{
    public class DatabaseInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Customers (
                                            Id CHAR(36) PRIMARY KEY, 
                                            Username TEXT NOT NULL,
                                            FullName TEXT NOT NULL,
                                            Email TEXT NOT NULL,
                                            DateOfBirth TEXT NOT NULL)");

            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS DbEntity (
                                            Id INTEGER PRIMARY KEY,
                                            Value TEXT NOT NULL
                                           )");
        }
    }
}