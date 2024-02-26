namespace HomesteadManagerApi.Models;

public class Plant
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public bool Annual { get; set; }
    public bool IndoorSow { get; set; }
    public float? PlantingSize { get; set; }
    public float? PlantingDepth { get; set; }
    public SunPreference? SunPreference { get; set; }
    public Season? SowingSeason { get; set; }
    public Plant[] CompanionPlants { get; set; } = [];
    public Plant[] SuccessionPlants { get; set; } = [];
}