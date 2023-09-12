using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SqliteNativeDataTypesAsyncController : ControllerBase
    {
        private readonly ISqliteNativeDataTypesRepository _repository;

        public SqliteNativeDataTypesAsyncController(ISqliteNativeDataTypesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{myInteger}")]
        public async Task<SqliteNativeDataTypes?> GetAsync(int myInteger)
        {
            return await _repository.GetAsync(myInteger);
        }

        [HttpGet]
        public async Task<IEnumerable<SqliteNativeDataTypes>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<bool> CreateAsync([FromBody] SqliteNativeDataTypes entity)
        {
            return await _repository.CreateAsync(entity);
        }

        [HttpPatch]
        public async Task<bool> UpdateAsync([FromBody] SqliteNativeDataTypes entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        [HttpDelete("{myInteger}")]
        public async Task<bool> DeleteAsync(int myInteger)
        {
            return await _repository.DeleteAsync(myInteger);
        }

        [HttpPost("truncate")]
        public async Task<IActionResult> TruncateAsync()
        {
            await _repository.TruncateAsync();
            return NoContent();
        }
    }
}