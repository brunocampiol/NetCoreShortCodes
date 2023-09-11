using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SqliteNativeDataTypesController : ControllerBase
    {
        private readonly ISqliteNativeDataTypesRepository _repository;

        public SqliteNativeDataTypesController(ISqliteNativeDataTypesRepository repository)
        {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets first or default SqliteNativeDataTypes entry
        /// </summary>
        /// <param name="myInteger"></param>
        /// <returns></returns>
        [HttpGet("{myInteger}")]
        public async Task<SqliteNativeDataTypes?> Get(int myInteger)
        {
            return await _repository.GetAsync(myInteger);
        }

        /// <summary>
        /// Gets all SqliteNativeDataTypes entries
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<SqliteNativeDataTypes>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>
        /// Create SqliteNativeDataTypes entry
        /// </summary>
        [HttpPost]
        public async Task<bool> Create([FromBody] SqliteNativeDataTypes dbEntity)
        {
            return await _repository.CreateAsync(dbEntity);
        }

        /// <summary>
        /// Update SqliteNativeDataTypes entry
        /// </summary>
        [HttpPatch]
        public async Task<bool> Update([FromBody] SqliteNativeDataTypes dbEntity)
        {
            return await _repository.UpdateAsync(dbEntity);
        }

        /// <summary>
        /// Delete SqliteNativeDataTypes entry
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int myInteger)
        {
            return await _repository.DeleteAsync(myInteger);
        }

    }
}