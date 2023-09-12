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

        // Async

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
        public async Task<bool> Create([FromBody] SqliteNativeDataTypes entity)
        {
            return await _repository.CreateAsync(entity);
        }

        /// <summary>
        /// Update SqliteNativeDataTypes entry
        /// </summary>
        [HttpPatch]
        public async Task<bool> Update([FromBody] SqliteNativeDataTypes entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// Delete SqliteNativeDataTypes entry
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{myInteger}")]
        public async Task<bool> Delete(int myInteger)
        {
            return await _repository.DeleteAsync(myInteger);
        }

        // Sync

        [HttpGet("sync/{myInteger}")]
        public SqliteNativeDataTypes? GetSync(int myInteger)
        {
            return _repository.Get(myInteger);
        }

        [HttpGet("sync")]
        public IEnumerable<SqliteNativeDataTypes> GetAllSync()
        {
            return _repository.GetAll();
        }

        [HttpPost("sync")]
        public bool CreateSync([FromBody] SqliteNativeDataTypes entity)
        {
            return _repository.Create(entity);
        }

        [HttpPatch("sync")]
        public bool UpdateSync([FromBody] SqliteNativeDataTypes entity)
        {
            return _repository.Update(entity);
        }

        [HttpDelete("sync/{myInteger}")]
        public bool DeleteSync(int myInteger)
        {
            return _repository.Delete(myInteger);
        }
    }
}