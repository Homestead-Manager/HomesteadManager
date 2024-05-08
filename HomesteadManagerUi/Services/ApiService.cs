using HomesteadManager.Shared.Models;
using HomesteadManager.Shared.Requests;
using HomesteadManager.Shared.Responses;
using System.Net.Http.Json;
using System.Text.Json;

namespace HomesteadManagerUi.Services
{
    public class ApiService
    {
        private HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetHealthcheck()
        {
            return await _httpClient.GetStringAsync("/api/chat/healthcheck");
        }

        public async Task<List<PlantZoneInfo>> GetPlants(string zipCode)
        {
            return await _httpClient.GetFromJsonAsync<List<PlantZoneInfo>>($"/api/chat/plants?zipCode={zipCode}") ?? [];
        }

        public async Task<GardenResponse> GetSuggestedLayout(GardenRecommendationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/chat/garden", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GardenResponse>();
            }
            return await Task.FromResult(JsonSerializer.Deserialize<GardenResponse>("{\"Gardens\":[{\"GardenID\":1,\"Dimensions\":{\"Height\":1,\"Width\":3,\"Length\":4,\"Unit\":\"feet\"},\"Plants\":[{\"Plant\":\"Tomato\",\"Quantity\":4},{\"Plant\":\"Borage\",\"Quantity\":2}],\"Notes\":\"Borage helps tomatoes by repelling pests and improving growth.\"},{\"GardenID\":2,\"Dimensions\":{\"Height\":1,\"Width\":3,\"Length\":4,\"Unit\":\"feet\"},\"Plants\":[{\"Plant\":\"Jalapeno\",\"Quantity\":6}],\"Notes\":\"Jalapenos alone to avoid cross-pollination issues.\"},{\"GardenID\":3,\"Dimensions\":{\"Height\":1,\"Width\":3,\"Length\":4,\"Unit\":\"feet\"},\"Plants\":[{\"Plant\":\"Cucumber\",\"Quantity\":4}],\"Notes\":\"Planted alone; use trellising to maximize space.\"},{\"GardenID\":4,\"Dimensions\":{\"Height\":1,\"Width\":3,\"Length\":6,\"Unit\":\"feet\"},\"Plants\":[{\"Plant\":\"Cabbage\",\"Quantity\":6}],\"Notes\":\"Cabbage can be densely Planted; monitor for pests.\"},{\"GardenID\":5,\"Dimensions\":{\"Height\":1,\"Width\":3,\"Length\":6,\"Unit\":\"feet\"},\"Plants\":[{\"Plant\":\"Cabbage\",\"Quantity\":6},{\"Plant\":\"Borage\",\"Quantity\":2}],\"Notes\":\"Borage can help deter cabbage worms.\"}]}"));
        }
    }
}
