using System.Collections.Generic;

namespace HomesteadManagerApi.Models
{
    public class SoilType
    {
        public int SoilTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BestUses { get; set; }

        // Navigation properties
        public ICollection<BedSoilType> BedSoilTypes { get; set; } = new List<BedSoilType>();
    }
}