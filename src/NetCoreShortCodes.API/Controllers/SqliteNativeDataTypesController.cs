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

        [HttpGet("{myInteger}")]
        public SqliteNativeDataTypes? Get(int myInteger)
        {
            return _repository.Get(myInteger);
        }

        [HttpGet]
        public IEnumerable<SqliteNativeDataTypes> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public bool Create([FromBody] SqliteNativeDataTypes entity)
        {
            return _repository.Create(entity);
        }

        [HttpPatch]
        public bool Update([FromBody] SqliteNativeDataTypes entity)
        {
            return _repository.Update(entity);
        }

        [HttpDelete("{myInteger}")]
        public bool Delete(int myInteger)
        {
            return _repository.Delete(myInteger);
        }

        [HttpPost("truncate")]
        public IActionResult Truncate()
        {
            _repository.Truncate();
            return NoContent();
        }
    }
}