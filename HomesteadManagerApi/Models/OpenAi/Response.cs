using Newtonsoft.Json;

namespace HomesteadManagerApi.Models.OpenAi
{
    public class Response
    {
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }
    }
}
