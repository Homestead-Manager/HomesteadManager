namespace HomesteadManagerUi.Services
{
    public class ApiService
    {
        private HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetHelloWorld()
        {
            return await _httpClient.GetStringAsync("/api/chat/hello");
        }
    }
}
