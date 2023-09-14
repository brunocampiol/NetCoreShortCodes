using Microsoft.AspNetCore.Mvc;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MockController : ControllerBase
    {
        public MockController()
        {
            
        }

        /// <summary>
        /// Mocks a response and return based on inputs
        /// </summary>
        /// <param name="delayMilliseconds">Optional: waits for the specified milliseconds</param>
        /// <param name="customResponse">Optional: custom message to return</param>
        /// <param name="statusCode">The HTTP status code to return</param>
        /// <returns></returns>
        [HttpGet("{statusCode}")]
        public async Task<IActionResult> Get([FromHeader] int? delayMilliseconds,
                                             [FromHeader] string? customResponse,
                                             int statusCode)
        {
            if (delayMilliseconds.HasValue)
            {
                await Task.Delay(delayMilliseconds.Value);
            }

            return StatusCode(statusCode, customResponse);
        }

        /// <summary>
        /// Throws a NotImplementedException having the optional message
        /// </summary>
        /// <param name="exceptionMessage"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete]
        public IActionResult Delete(string? exceptionMessage)
        {
            throw new NotImplementedException(exceptionMessage);
        }
    }
}