using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models;
using NetCoreShortCodes.API.Services;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AsyncEnumerableController : ControllerBase
    {
        // The IAsyncEnumerable as of 2023-06-28 does not work on swagger ui / postman.
        // To see the results as streams, hit the endpoint with the browser
        // TODO fix IAsyncEnumerable on postman / swagger ui

        /// <summary>
        /// Returns an async stream of integers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IAsyncEnumerable<int> Get() => AsyncEnumerableService.FetchAsyncEnumerableOfIntegers();

        /// <summary>
        /// Returns an async stream of integers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("weather")]
        public IAsyncEnumerable<WeatherForecast> GetWeather() => AsyncEnumerableService.FetchAsyncEnumerableOfWeatherForecast();
    }
}