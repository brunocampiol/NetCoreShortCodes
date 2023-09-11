using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{
    // TODO: fix swagger UI data types in NET
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

        // INPUT FOR POSTMAN
        //        {
        //  "myBool": false,
        //  "myByte": 0,
        //  "myChar": "A",
        //  "myDateOnly": "2023-09-11",
        //  "myDateTime": "2023-09-11T19:02:55.944Z",
        //  "myDateTimeOffset": "2023-09-11T19:02:55.944Z",
        //  "myDecimal": 1.000001,
        //  "myDouble": 1.0000002,
        //  "myGuid": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
        //  "myInt": 1,
        //  "myString": "string",
        //  "myTimeOnly": "23:59:59.0000000",
        //  "myTimeSpan": "0.01:00:00.0000000"
        //}
        [HttpPost]
        public async Task<bool> Create([FromBody] SqliteSupportedNetTypes dbEntity)
        {
            return await _repository.CreateAsync(dbEntity);
        }

        [HttpPatch]
        public async Task<bool> Update([FromBody] SqliteSupportedNetTypes dbEntity)
        {
            return await _repository.UpdateAsync(dbEntity);
        }

        [HttpDelete("{myGuid}")]
        public async Task<bool> Delete(Guid myGuid)
        {
            return await _repository.DeleteAsync(myGuid);
        }
    }
}
