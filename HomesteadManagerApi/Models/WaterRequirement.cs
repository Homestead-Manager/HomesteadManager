namespace HomesteadManagerApi.Models
{
    public enum WaterRequirement
    {
        VeryLow,  // Suitable for plants that are drought-tolerant, often found in xeriscaping.
        Low,      // Needs occasional watering, perhaps once a week under normal conditions.
        Medium,   // Requires watering a few times a week to maintain consistent moisture.
        High,     // Prefers moist conditions and needs frequent watering.
        VeryHigh  // Requires daily watering or constant moisture, often found for aquatic or bog plants.
    }
}