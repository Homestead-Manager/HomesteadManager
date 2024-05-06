using System;

namespace HomesteadManagerApi.Models
{
    public class BedPlant
    {
        public int BedID { get; set; }
        public int PlantID { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime? HarvestDate { get; set; } // Nullable for future harvest dates

        // Navigation properties
        public Bed Bed { get; set; }
        public Plant Plant { get; set; }
    }
}
