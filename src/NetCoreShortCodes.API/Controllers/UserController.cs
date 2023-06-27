using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models.Entity;
using NetCoreShortCodes.API.Repositories;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// Gets first or default User entry
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User?> Get(string username)
        {
            return await _userRepository.GetAsync(username);
        }

        /// <summary>
        /// Gets all User entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Create a User entry
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userRepository.CreateAsync(user);
            return NoContent();
        }

        /// <summary>
        /// Update User entry
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        /// <summary>
        /// Delete User entry
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string username)
        {
            await _userRepository.DeleteAsync(username);
            return NoContent();
        }
    }
}