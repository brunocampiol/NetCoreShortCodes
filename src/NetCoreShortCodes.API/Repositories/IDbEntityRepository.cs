using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public interface IDbEntityRepository
    {
        Task<bool> CreateAsync(DbEntity dbEntity);

        Task<DbEntity?> GetAsync(int id);

        Task<IEnumerable<DbEntity>> GetAllAsync();

        Task<bool> UpdateAsync(DbEntity dbEntity);

        Task<bool> DeleteAsync(int id);
    }
}