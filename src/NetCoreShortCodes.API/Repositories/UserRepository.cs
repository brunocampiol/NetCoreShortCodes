using Dapper;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> CreateAsync(User user)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO Users (IsActive, Karma, Username, DateCreated) 
                VALUES (@IsActive, @Karma, @Username, @DateCreated)",
                user);
            return result == 1;
        }

        //public async Task<bool> DeleteAsync(Guid id)
        public async Task<bool> DeleteAsync(string username)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"DELETE FROM Users WHERE Username = @Username",
                new { Username = username });
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<User>("SELECT * FROM Users");
        }

        //public async Task<User?> GetAsync(Guid id)
        public async Task<User?> GetAsync(string username)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Username = @Username LIMIT 1",
                new { Username = username });
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE Users SET IsActive = @IsActive, Karma = @Karma, DateCreated = @DateCreated
                WHERE Username = @Username",
                user);
            return result > 0;
        }
    }
}