using NetCoreShortCodes.API.Models;

namespace NetCoreShortCodes.API.Services
{
    public static class AsyncEnumerableService
    {
        public static async IAsyncEnumerable<int> FetchAsyncEnumerableOfIntegers()
        {
            var random = new Random();
            var maxItems = random.Next(100, 10_000);

            for (int i = 1; i <= maxItems; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public static async IAsyncEnumerable<WeatherForecast> FetchAsyncEnumerableOfWeatherForecast()
        {
            var random = new Random();
            var maxItems = random.Next(100, 10_000);

            for (int i = 1; i <= maxItems; i++)
            {
                await Task.Delay(100);
                var forecast = new WeatherForecast()
                {
                    TemperatureC = random.Next(-50, 50)
                };

                switch (forecast.TemperatureC)
                {
                    case < 0:
                        forecast.Summary = "Very cold";
                        break;
                    case < 16:
                        forecast.Summary = "Cold";
                        break;
                    case < 26:
                        forecast.Summary = "Warm";
                        break;
                    case < 36:
                        forecast.Summary = "Hot";
                        break;
                    case < 46:
                        forecast.Summary = "Boiling";
                        break;
                    default:
                        forecast.Summary = "Sweltering";
                        break;
                }

                yield return forecast;
            }
        }
    }
}