using Newtonsoft.Json;

namespace HomesteadManagerApi.Models.OpenAi
{
    public class Choice
    {
        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("message")]
        public Prompt Message { get; set; }
    }
}
