using System.Collections.Generic;

namespace HomesteadManagerApi.Models
{
    public class Bed
    {
        public int BedID { get; set; }
        public int GardenID { get; set; }
        public decimal Size { get; set; }
        public Orientation Orientation { get; set; }
        
        // Navigation properties
        public Garden Garden { get; set; }
        public ICollection<BedSoilType> BedSoilTypes { get; set; } = new List<BedSoilType>();
        public ICollection<BedGardenStructure> BedGardenStructures { get; set; } = new List<BedGardenStructure>();
        public ICollection<BedPlant> BedPlants { get; set; } = new List<BedPlant>();
    }
}