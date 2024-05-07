namespace HomesteadManager.Shared.Models;

public class BedSoilType
{
    public int BedID { get; set; }
    public int SoilTypeID { get; set; }
    public decimal Depth { get; set; }
    public decimal Quantity { get; set; }

    // Navigation properties
    public Bed Bed { get; set; }
    public SoilType SoilType { get; set; }
}
