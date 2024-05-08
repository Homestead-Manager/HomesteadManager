using HomesteadManager.Shared.Models;
using HomesteadManager.Shared.Requests;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

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
            return await _httpClient.GetFromJsonAsync<List<PlantZoneInfo>>($"/api/chat/plants?zipCode={zipCode}");
        }

        public async Task<Garden?> GetSuggestedLayout(GardenRecommendationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/chat/garden", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Garden?>();
            }
            return null;
        }
    }
}
