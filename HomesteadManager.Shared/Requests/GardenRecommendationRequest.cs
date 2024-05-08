namespace HomesteadManager.Shared.Requests
{
    public class GardenRecommendationRequest
    {
        public string ZoneCode { get; set; }
        public List<PlantRequest> Plants { get; set; }

        public List<GardenRequest> Gardens { get; set; }
    }
}
