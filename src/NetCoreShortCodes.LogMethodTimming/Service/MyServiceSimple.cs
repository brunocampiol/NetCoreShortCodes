using MethodTimer;
using System.Net;

namespace NetCoreShortCodes.LogMethodTimming.Service
{
    public sealed class MyServiceSimple
    {
        public MyServiceSimple()
        {
            
        }

        // Attribute 'Time' here logs in VisualStudio Output
        // look for Debug output from that panel
        [Time] 
        public async Task<HttpStatusCode> GetHttpStatusCode()
        {
            var nextInt = Random.Shared.Next(3, 40);
            await Task.Delay(nextInt); // adds random delay

            switch (nextInt)
            {
                case int n when (n < 10):
                    return HttpStatusCode.Accepted;
                case int n when (n < 20):
                    return HttpStatusCode.NoContent;
                case int n when (n < 30):
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.OK;
            }

        }
    }
}