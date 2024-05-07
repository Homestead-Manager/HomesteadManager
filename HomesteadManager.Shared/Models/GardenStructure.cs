namespace HomesteadManager.Shared.Models;

public class GardenStructure
{
    public int StructureID { get; set; }
    public GardenStructureType Type { get; set; }
    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Height { get; set; }

    // Navigation properties
    public ICollection<BedGardenStructure> BedGardenStructures { get; set; } = new List<BedGardenStructure>();
}
