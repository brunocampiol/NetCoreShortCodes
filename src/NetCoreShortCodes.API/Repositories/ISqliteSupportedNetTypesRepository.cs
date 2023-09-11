using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public interface ISqliteSupportedNetTypesRepository
    {
        Task<bool> CreateAsync(SqliteSupportedNetTypes entity);
        Task<bool> DeleteAsync(Guid myGuid);
        Task<IEnumerable<SqliteSupportedNetTypes>> GetAllAsync();
        Task<SqliteSupportedNetTypes?> GetAsync(Guid myGuid);
        Task<bool> UpdateAsync(SqliteSupportedNetTypes entity);
    }
}