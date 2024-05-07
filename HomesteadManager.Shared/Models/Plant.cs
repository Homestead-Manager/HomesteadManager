using System.Collections.Generic;

namespace HomesteadManager.Shared.Models;

public class Plant
{
    public int PlantID { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string PlantType { get; set; }
    public string SunRequirement { get; set; }
    public string WateringRequirement { get; set; }
}
