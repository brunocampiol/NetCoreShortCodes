using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DbEntityController : ControllerBase
    {
        private readonly IDbEntityRepository _dbEntityRepository;

        public DbEntityController(IDbEntityRepository dbEntityRepository)
        {
            _dbEntityRepository = dbEntityRepository ?? throw new ArgumentNullException(nameof(dbEntityRepository));
        }

        /// <summary>
        /// Gets first or default DbEntity entry
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<DbEntity?> Get(int id)
        {
            return await _dbEntityRepository.GetAsync(id);
        }

        /// <summary>
        /// Gets all DbEntity entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DbEntity>> GetAll()
        {
            return await _dbEntityRepository.GetAllAsync();
        }

        /// <summary>
        /// Create a DbEntity entry
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] DbEntity dbEntity)
        {
            await _dbEntityRepository.CreateAsync(dbEntity);
            return NoContent();
        }
    }
}