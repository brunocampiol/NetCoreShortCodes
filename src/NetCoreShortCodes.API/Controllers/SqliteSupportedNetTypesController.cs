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
        public SqliteSupportedNetTypes? Get(Guid myGuid)
        {
            return _repository.Get(myGuid);
        }

        [HttpGet]
        public IEnumerable<SqliteSupportedNetTypes> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public bool Create([FromBody] SqliteSupportedNetTypes entity)
        {
            return _repository.Create(entity);
        }

        [HttpPatch]
        public bool Update([FromBody] SqliteSupportedNetTypes entity)
        {
            return _repository.Update(entity);
        }

        [HttpDelete("{myGuid}")]
        public bool Delete(Guid myGuid)
        {
            return _repository.Delete(myGuid);
        }
    }
}