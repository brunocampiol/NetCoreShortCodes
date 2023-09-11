using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SqliteSupportedNetTypesController : ControllerBase
    {
        private readonly ISqliteSupportedNetTypesRepository _repository;

        public SqliteSupportedNetTypesController(ISqliteSupportedNetTypesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{myGuid}")]
        public async Task<SqliteSupportedNetTypes?> Get(Guid myGuid)
        {
            return await _repository.GetAsync(myGuid);
        }

        [HttpGet]
        public async Task<IEnumerable<SqliteSupportedNetTypes>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<bool> Create([FromBody] SqliteSupportedNetTypes entity)
        {
            return await _repository.CreateAsync(entity);
        }

        [HttpPatch]
        public async Task<bool> Update([FromBody] SqliteSupportedNetTypes entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        [HttpDelete("{myGuid}")]
        public async Task<bool> Delete(Guid myGuid)
        {
            return await _repository.DeleteAsync(myGuid);
        }
    }
}