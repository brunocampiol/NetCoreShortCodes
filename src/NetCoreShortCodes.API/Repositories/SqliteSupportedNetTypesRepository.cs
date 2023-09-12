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

        public bool Create(SqliteSupportedNetTypes entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
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

        public bool Delete(Guid myGuid)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
                @"DELETE FROM SqliteSupportedNetTypes WHERE MyGuid = @MyGuid",
                new { MyGuid = myGuid });
            return result == 1;
        }

        public SqliteSupportedNetTypes? Get(Guid myGuid)
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.QuerySingleOrDefault<SqliteSupportedNetTypes>(
                "SELECT * FROM SqliteSupportedNetTypes WHERE MyGuid = @MyGuid LIMIT 1",
                new { MyGuid = myGuid });
        }

        public IEnumerable<SqliteSupportedNetTypes> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();
            return connection.Query<SqliteSupportedNetTypes>("SELECT * FROM SqliteSupportedNetTypes");
        }

        public bool Update(SqliteSupportedNetTypes entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = connection.Execute(
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