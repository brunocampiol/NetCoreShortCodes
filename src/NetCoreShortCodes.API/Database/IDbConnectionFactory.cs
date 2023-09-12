using System.Data;

namespace NetCoreShortCodes.API.Database
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync();

        public IDbConnection CreateConnection();
    }
}