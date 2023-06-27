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
            // Id CHAR(36) PRIMARY KEY,
            // DateOfBirth TEXT,
            using var connection = await _connectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Users (              
                                            IsActive INTEGER NOT NULL,
                                            Karma INTEGER NOT NULL,
                                            Username TEXT NOT NULL,
                                            DateCreated TEXT NOT NULL)");

            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS DbEntity (
                                            Id INTEGER PRIMARY KEY,
                                            Value TEXT NOT NULL
                                           )");
        }
    }
}