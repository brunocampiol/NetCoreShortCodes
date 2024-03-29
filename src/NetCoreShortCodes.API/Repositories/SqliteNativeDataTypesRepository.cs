﻿using Dapper;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    // https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/async
    // Async operations here are just for demonstration. See above link.

    public class SqliteNativeDataTypesRepository : ISqliteNativeDataTypesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SqliteNativeDataTypesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> CreateAsync(SqliteNativeDataTypes sqliteNativeDataTypes)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO SqliteNativeDataTypes (MyInteger, MyReal, MyText) 
                VALUES (@MyInteger, @MyReal, @MyText)",
                sqliteNativeDataTypes);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(int myInteger)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"DELETE FROM SqliteNativeDataTypes WHERE MyInteger = @MyInteger",
                new { MyInteger = myInteger });
            return result == 1;
        }

        public async Task<IEnumerable<SqliteNativeDataTypes>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<SqliteNativeDataTypes>("SELECT * FROM SqliteNativeDataTypes");
        }

        public async Task<SqliteNativeDataTypes?> GetAsync(int myInteger)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<SqliteNativeDataTypes>(
                "SELECT * FROM SqliteNativeDataTypes WHERE MyInteger = @MyInteger LIMIT 1",
                new { MyInteger = myInteger });
        }

        public async Task<bool> UpdateAsync(SqliteNativeDataTypes sqliteNativeDataTypes)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE SqliteNativeDataTypes SET MyReal = @MyReal, MyText = @MyText 
                WHERE MyInteger = @MyInteger",
                sqliteNativeDataTypes);
            return result == 1;
        }

        public bool Create(SqliteNativeDataTypes sqliteNativeDataTypes)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
                @"INSERT INTO SqliteNativeDataTypes (MyInteger, MyReal, MyText) 
                VALUES (@MyInteger, @MyReal, @MyText)",
                sqliteNativeDataTypes);
            return result == 1;
        }

        public bool Delete(int myInteger)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
                @"DELETE FROM SqliteNativeDataTypes WHERE MyInteger = @MyInteger",
                new { MyInteger = myInteger });
            return result == 1;
        }

        public SqliteNativeDataTypes? Get(int myInteger)
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.QuerySingleOrDefault<SqliteNativeDataTypes>(
                "SELECT * FROM SqliteNativeDataTypes WHERE MyInteger = @MyInteger LIMIT 1",
                new { MyInteger = myInteger });
        }

        public IEnumerable<SqliteNativeDataTypes> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<SqliteNativeDataTypes>("SELECT * FROM SqliteNativeDataTypes");
        }

        public bool Update(SqliteNativeDataTypes sqliteNativeDataTypes)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
                @"UPDATE SqliteNativeDataTypes SET MyReal = @MyReal, MyText = @MyText 
                WHERE MyInteger = @MyInteger",
                sqliteNativeDataTypes);
            return result == 1;
        }

        public async Task TruncateAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM SqliteNativeDataTypes");
        }

        public void Truncate()
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(@"DELETE FROM SqliteNativeDataTypes");
        }
    }
}