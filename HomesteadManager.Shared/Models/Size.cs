namespace HomesteadManager.Shared.Models
{
    public class Size
    {
        public int Height { get; set; } = 1;
        public int Width { get; set; }
        public int Length { get; set; }
        public string Unit { get; set; } = "feet";
    }
}
