using HomesteadManagerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return await service.CallEndpointAsync($"Plants that grow in {zipcode}. Respond with a list of JSON objects in this format: {schema}");
        }
    }
}
