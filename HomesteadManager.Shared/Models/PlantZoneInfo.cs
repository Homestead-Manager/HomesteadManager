
namespace HomesteadManager.Shared.Models;

// This class links plants to particular zones and includes any relevant information specific to growing that plant in that zone.
public class PlantZoneInfo
{
    public int PlantID { get; set; } // FK to Plant
    public Plant Plant { get; set; }

    public string ZoneID { get; set; } // Zone identifier such as "7a"

    // Additional zone-specific properties for the plant
    public string SowingMethod { get; set; }
    public DateTime? OptimalSowingPeriodStart { get; set; }
    public DateTime? OptimalSowingPeriodEnd { get; set; }
    public DateTime? HarvestPeriodStart { get; set; }
    public DateTime? HarvestPeriodEnd { get; set; }

    // This could also include notes on growing conditions or care instructions specific to the zone
    public string ZoneSpecificNotes { get; set; }
}
