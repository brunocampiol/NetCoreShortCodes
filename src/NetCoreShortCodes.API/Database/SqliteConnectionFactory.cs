﻿using Microsoft.Data.Sqlite;
using System.Data;

namespace NetCoreShortCodes.API.Database
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}