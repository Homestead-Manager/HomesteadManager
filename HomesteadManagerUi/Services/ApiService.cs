using HomesteadManager.Shared.Models;
using System.Net.Http.Json;

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

        public async Task<List<PlantZoneInfo>> GetPlants(string zipCode)
        {
            return await _httpClient.GetFromJsonAsync<List<PlantZoneInfo>>($"/api/chat/plants?zipCode={zipCode}") ?? [];
        }
    }
}
