using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public interface ISqliteNativeDataTypesRepository
    {
        Task<bool> CreateAsync(SqliteNativeDataTypes sqliteNativeDataTypes);
        Task<bool> DeleteAsync(int myInteger);
        Task<IEnumerable<SqliteNativeDataTypes>> GetAllAsync();
        Task<SqliteNativeDataTypes?> GetAsync(int myInteger);
        Task<bool> UpdateAsync(SqliteNativeDataTypes sqliteNativeDataTypes);
        bool Create(SqliteNativeDataTypes sqliteNativeDataTypes);
        bool Delete(int myInteger);
        IEnumerable<SqliteNativeDataTypes> GetAll();
        SqliteNativeDataTypes? Get(int myInteger);
        bool Update(SqliteNativeDataTypes sqliteNativeDataTypes);
    }
}