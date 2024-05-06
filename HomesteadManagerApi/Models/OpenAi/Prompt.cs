using Newtonsoft.Json;

namespace HomesteadManagerApi.Models.OpenAi
{
    public class Prompt
    {
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
