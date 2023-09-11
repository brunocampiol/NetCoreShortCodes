using Dapper;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public class SqliteSupportedNetTypesRepository : ISqliteSupportedNetTypesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SqliteSupportedNetTypesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> CreateAsync(SqliteSupportedNetTypes entity)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO SqliteSupportedNetTypes (MyBool, 
                                                       MyByte, 
                                                       MyChar,
                                                       MyDateOnly,
                                                       MyDateTime,
                                                       MyDateTimeOffset,
                                                       MyDecimal,
                                                       MyDouble,
                                                       MyGuid,
                                                       MyInt,
                                                       MyString,
                                                       MyTimeOnly,
                                                       MyTimeSpan) 
                VALUES (@MyBool, 
                        @MyByte, 
                        @MyChar,
                        @MyDateOnly,
                        @MyDateTime,
                        @MyDateTimeOffset,
                        @MyDecimal,
                        @MyDouble,
                        @MyGuid,
                        @MyInt,
                        @MyString,
                        @MyTimeOnly,
                        @MyTimeSpan) ",
                entity);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid myGuid)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"DELETE FROM SqliteSupportedNetTypes WHERE MyGuid = @MyGuid",
                new { MyGuid = myGuid });
            return result == 1;
        }

        public async Task<IEnumerable<SqliteSupportedNetTypes>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<SqliteSupportedNetTypes>("SELECT * FROM SqliteSupportedNetTypes");
        }

        public async Task<SqliteSupportedNetTypes?> GetAsync(Guid myGuid)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<SqliteSupportedNetTypes>(
                "SELECT * FROM SqliteSupportedNetTypes WHERE MyGuid = @MyGuid LIMIT 1",
                new { MyGuid = myGuid });
        }

        public async Task<bool> UpdateAsync(SqliteSupportedNetTypes entity)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE SqliteSupportedNetTypes SET MyBool = @MyBool, 
                                                     MyByte = @MyByte,
                                                     MyChar = @MyChar,
                                                     MyDateOnly = @MyDateOnly,
                                                     MyDateTime = @MyDateTime,
                                                     MyDateTimeOffset = @MyDateTimeOffset,
                                                     MyDecimal = @MyDecimal,
                                                     MyDouble = @MyDouble,
                                                     MyInt = @MyInt,
                                                     MyString = @MyString,
                                                     MyTimeOnly = @MyTimeOnly,
                                                     MyTimeSpan = @MyTimeSpan
                WHERE MyGuid = @MyGuid",
                entity);
            return result == 1;
        }
    }
}