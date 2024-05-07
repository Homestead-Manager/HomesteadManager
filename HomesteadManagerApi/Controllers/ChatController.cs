using HomesteadManagerApi.Interfaces;
using HomesteadManagerApi.Models;
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
        private readonly string schema = "{\"Plant\": {\"CommonName\": \"\", \"ScientificName\": \"\", \"PlantType\": \"\", \"SunRequirement\": \"\", \"WaterRequirement\": \"\"}, \"ZoneID\": \"\", \"SowingMethod\": \"\", \"OptimalSowingPeriodStart\": \"yyyy-mm-dd\", \"OptimalSowingPeriodEnd\": \"yyyy-mm-dd\", \"HarvestPeriodStart\": \"yyyy-mm-dd\", \"HarvestPeriodEnd\": \"yyyy-mm-dd\", \"ZoneSpecificNotes\": \"\"}";
        public ChatController(IOpenAIService openAIService)
        {
            service = openAIService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPlants(string zipcode)
        {
            var result = await service.CallEndpointAsync($"Plants that grow in {zipcode}. Respond with a list of JSON objects in this format: {schema}");

            var response = JsonConvert.DeserializeObject<Response>(result);

            var assistantResponse = response?.Choices.FirstOrDefault(x => x.Message.Role == PromptType.Assistant);

            var plantResponse = JsonConvert.DeserializeObject<List<PlantZoneInfo>>(assistantResponse.Message.Content);
            return Ok(plantResponse);
            //var response = JsonConvert.DeserializeObject<List<PlantZoneInfo>>(result);
            //return Ok(response);
        }
    }
}
