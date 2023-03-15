using MethodTimer;
using System.Net;

namespace NetCoreShortCodes.LogMethodTimming.Service
{
    public sealed class MyService
    {
        private readonly Random _random = new Random(420);

        public MyService()
        {
            
        }

        // Attribute 'Time' here logs time to trace
        [Time]
        public async Task<HttpStatusCode> GetHttpStatusCode()
        {
            var miliseconds = _random.NextDouble();
            await Task.Delay(TimeSpan.FromMilliseconds(miliseconds));
            return HttpStatusCode.OK;
        }
    }
}