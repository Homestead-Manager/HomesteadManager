using HomesteadManager.Shared.Models;
using HomesteadManager.Shared.Requests;
using HomesteadManager.Shared.Responses;
using HomesteadManagerApi.Interfaces;
using HomesteadManagerApi.Models.OpenAi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomesteadManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IOpenAIService service;

        public ChatController(IOpenAIService openAIService)
        {
            service = openAIService;
        }

        [HttpGet("plants")]
        public async Task<ActionResult<List<PlantZoneInfo>>> GetPlants(string zipcode)
        {
            var schema = "[{\"Plant\": {\"CommonName\": \"\", \"ScientificName\": \"\", \"PlantType\": \"\", \"SunRequirement\": \"\", \"WaterRequirement\": \"\"}, \"ZoneID\": \"\", \"SowingMethod\": \"\", \"OptimalSowingPeriodStart\": \"yyyy-mm-dd\", \"OptimalSowingPeriodEnd\": \"yyyy-mm-dd\", \"HarvestPeriodStart\": \"yyyy-mm-dd\", \"HarvestPeriodEnd\": \"yyyy-mm-dd\", \"ZoneSpecificNotes\": \"\"}]";
            var prompt = $"Give me a list of at least 10 Plants that grow in {zipcode}. Respond with a list of JSON objects in this format: {schema}. Use the USDA plant hardiness zone cooresponding to the provided zip code as the ZoneID";
            var assistantResponse = await GetAsistantResponse(prompt);

            if (assistantResponse != null)
            {
                var plantResponse = JsonConvert.DeserializeObject<List<PlantZoneInfo>>(assistantResponse?.Message?.Content ?? string.Empty);
                return Ok(plantResponse);
            }

            return NotFound("AssistantResponse returned null.");
        }

        [HttpGet("hello")]
        public ActionResult<string> Hello()
        {
            return Ok("Hello World");
        }

        [HttpPost("garden")]
        public async Task<ActionResult<Garden>> GetRecommendedGarden(GardenRecommendationRequest request)
        {
            var schema = "{ \"Gardens\": [{\"GardenId\": 0, \"Dimensions\": { \"Width\": 3, \"Length\": 4, \"Unit\": \"feet\" },\"Plants\": [{ \"Plant\": \"Tomatoes\", \"Quantity\": 2 }], \"Notes\": \"any extra notes\"}]}";
            var prompt = $"I have these garden plots: {JsonConvert.SerializeObject(request.Gardens)}. " +
                $"Using these plots, give a recommended garden layout in zone {request.ZoneCode} based on companion plants and succession planting " +
                $"using these plants: {JsonConvert.SerializeObject(request.Plants)}. " +
                $"Respond with a list of JSON objects in this format: {schema}";

            var assistantResponse = await GetAsistantResponse(prompt);

            if (assistantResponse != null)
            {
                var gardenResponse = JsonConvert.DeserializeObject<GardenResponse>(assistantResponse?.Message?.Content ?? string.Empty);
                return Ok(gardenResponse);
            }

            return NotFound("AssistantResponse returned null.");
        }

        private async Task<Choice?> GetAsistantResponse(string prompt)
        {
            var result = await service.CallEndpointAsync(prompt);

            var response = JsonConvert.DeserializeObject<Response>(result);

            var assistantResponse = response?.Choices.FirstOrDefault(x => x.Message.Role == PromptType.Assistant);

            return assistantResponse;
        }
    }
}
