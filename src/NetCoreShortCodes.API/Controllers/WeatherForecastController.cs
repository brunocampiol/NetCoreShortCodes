using Microsoft.AspNetCore.Mvc;
using NetCoreShortCodes.API.Models;

namespace NetCoreShortCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets weather forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Forces weather temperature update in background
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "ForceWeatherUpdate")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Post()
        {
            Response.OnCompleted(async () =>
            {
                // Emulate long running process in background.
                await Task.Delay(10000);
                _logger.LogInformation("Completed background work");
            });

            return Accepted();
        }
    }
}