using System.Text.Json.Serialization;

namespace HomesteadManagerApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GardenStructureType
{
    Trellis,
    Arch,
    Cage,
    Fence
}
