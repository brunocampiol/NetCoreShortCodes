using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public interface ISqliteSupportedNetTypesRepository
    {
        bool Create(SqliteSupportedNetTypes entity);
        bool Delete(Guid myGuid);
        IEnumerable<SqliteSupportedNetTypes> GetAll();
        SqliteSupportedNetTypes? Get(Guid myGuid);
        bool Update(SqliteSupportedNetTypes entity);
    }
}