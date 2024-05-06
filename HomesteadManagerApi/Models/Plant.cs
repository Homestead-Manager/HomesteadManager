using System.Collections.Generic;

namespace HomesteadManagerApi.Models
{
    public class Plant
    {
        public int PlantID { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string PlantType { get; set; } // Consider using Enum for PlantType.
        public SunRequirement SunRequirement { get; set; }
        public string WateringRequirement { get; set; }

        // Navigation properties
        public ICollection<BedPlant> BedPlants { get; set; } = new List<BedPlant>();
    }
}
