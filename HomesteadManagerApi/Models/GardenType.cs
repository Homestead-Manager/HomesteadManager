using System.Text.Json.Serialization;

namespace HomesteadManagerApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GardenType
{
    RaisedBed,
    Greenhouse,
    NoDig,
    Tilleds
}
