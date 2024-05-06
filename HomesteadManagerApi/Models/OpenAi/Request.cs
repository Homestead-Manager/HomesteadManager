namespace HomesteadManagerApi.Models.OpenAi
{
    public class Request
    {
        public string Model { get; set; }
        public List<Prompt> Messages { get; set; }
        public decimal Temperature { get; set; } = 0.7m;
        public int max_tokens { get; set; } = 800;
        public decimal top_p { get; set; } = 0.95m;
        public int frequency_penalty { get; set; } = 0;
        public int presence_penalty { get; set; } = 0;

    }
}
