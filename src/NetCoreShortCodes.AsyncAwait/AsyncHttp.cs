namespace NetCoreShortCodes.AsyncAwait
{
    internal class AsyncHttp
    {
        private readonly HttpClient _httpClient;

        public AsyncHttp()
        {
            _httpClient= new HttpClient();
        }

        public async Task<string> GetHttpResponseNonCompliantAsync(Uri uri)
        {
            if (uri == null) { throw new ArgumentNullException(nameof(uri)); }

            var httpResponse = await _httpClient.GetAsync(uri);
            var content = await httpResponse.Content.ReadAsStringAsync();
           return content;
        }

        public Task<string> GetHttpResponseCompliantAsync(Uri uri)
        {
            if (uri == null) { throw new ArgumentNullException(nameof(uri)); }

            return GetHttpResponseCompliantInternalAsync(uri);
        }

        private async Task<string> GetHttpResponseCompliantInternalAsync(Uri uri)
        {
            var httpResponse = await _httpClient.GetAsync(uri);
            var content = await httpResponse.Content.ReadAsStringAsync();
            return content;
        }
    }
}