using HomesteadManagerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<string>> GetPlants(string zipcode)
        {
            return await service.CallEndpointAsync($"Plants that grow in {zipcode}");
        }
    }
}
