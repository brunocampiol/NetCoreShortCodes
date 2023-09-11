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
            // https://www.sqlite.org/stricttables.html
            // SQLite supports a strict typing mode, as of version 3.37.0 (2021-11-27)
            // The current nuget package for .NET targets version 3.35.5
            // SELECT sqlite_version()
            using var connection = await _connectionFactory.CreateConnectionAsync();

            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS SqliteNativeDataTypes 
                                            (              
	                                            MyInteger INTEGER PRIMARY KEY,
	                                            MyReal REAL NOT NULL,
	                                            MyText TEXT NOT NULL
                                            )");

            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS SqliteSupportedNetTypes 
                                            (
                                                MyBool INTERGER NOT NULL,
                                                MyByte INTERGER NOT NULL,
                                                MyChar TEXT NOT NULL,
                                                MyDateOnly TEXT NOT NULL,
                                                MyDateTime TEXT NOT NULL,
                                                MyDateTimeOffset TEXT NOT NULL,
                                                MyDecimal TEXT NOT NULL,
                                                MyDouble REAL NOT NULL,
                                                MyGuid TEXT PRIMARY KEY,
	                                            MyInt INTEGER NOT NULL,
	                                            MyString TEXT NOT NULL,
                                                MyTimeOnly TEXT NOT NULL,
                                                MyTimeSpan TEXT NOT NULL
                                            )");

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