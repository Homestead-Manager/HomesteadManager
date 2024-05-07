using System.Text.Json.Serialization;

namespace HomesteadManager.Shared.Models;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GardenType
{
    RaisedBed,
    Greenhouse,
    NoDig,
    Tilleds
}
