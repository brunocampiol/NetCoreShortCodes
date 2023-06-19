using Dapper;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public class DbEntityRepository : IDbEntityRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DbEntityRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> CreateAsync(DbEntity dbEntity)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO DbEntity (Id, Value) 
                VALUES (@Id, @Value)",
                dbEntity);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM DbEntity WHERE Id = @Id",
                new { Id = id.ToString() });
            return result > 0;
        }

        public async Task<IEnumerable<DbEntity>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<DbEntity>("SELECT * FROM DbEntity");
        }

        public async Task<DbEntity?> GetAsync(int id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<DbEntity>(
                "SELECT * FROM DbEntity WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
        }

        public async Task<bool> UpdateAsync(DbEntity dbEntity)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE DbEntity SET Value = @Value WHERE Id = @Id",
                dbEntity);
            return result > 0;
        }
    }
}