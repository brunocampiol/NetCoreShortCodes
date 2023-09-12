using System.Data;

namespace NetCoreShortCodes.API.Database
{
    public interface IDbConnectionFactory
    {
        // Do not use async connection in SQLite
        // https://stackoverflow.com/questions/42982444/entity-framework-core-sqlite-async-requests-are-actually-synchronous

        /// <summary>
        /// Demonstration only. Use sync connection for SQLite
        /// </summary>
        /// <returns></returns>
        public Task<IDbConnection> CreateConnectionAsync();

        public IDbConnection CreateConnection();
    }
}