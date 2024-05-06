namespace HomesteadManagerApi.Models
{
    public class BedGardenStructure
    {
        public int BedID { get; set; }
        public int StructureID { get; set; }
        
        // Navigation properties
        public Bed Bed { get; set; }
        public GardenStructure GardenStructure { get; set; }
    }
}