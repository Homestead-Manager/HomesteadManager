using Newtonsoft.Json;

namespace HomesteadManagerApi.Models.OpenAi
{
    public class Request
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<Prompt> Messages { get; set; }

        [JsonProperty("temperature")]
        public decimal Temperature { get; set; } = 0.7m;
        public int max_tokens { get; set; } = 3800;
        public decimal top_p { get; set; } = 0.95m;
        public int frequency_penalty { get; set; } = 0;
        public int presence_penalty { get; set; } = 0;

    }
}
