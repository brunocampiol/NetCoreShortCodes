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
            var result = await connection.ExecuteAsync(@"INSERT INTO Users (IsActive, Karma, Username, DateCreated) 
                                                        VALUES (@IsActive, @Karma, @Username, @DateCreated)",
                                                        user);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
