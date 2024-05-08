using HomesteadManager.Shared.Models;
namespace HomesteadManager.Shared.Responses
{
    public class GardenResponse
    {
        public List<GardenResponseItem> Gardens { get; set; }
    }

    public class GardenResponseItem
    {
        public int GardenID { get; set; }
        public Size Dimensions { get; set; }
        public List<GardenResponseItem> Plants { get; set; }
        public string? Notes;

    }

    public class GardenPlantResponse
    {
        public string Plant { get; set; }
        public int Quantity { get; set; }
    }
}


