using System.Text.Json.Serialization;

namespace HomesteadManager.Shared.Models;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GardenStructureType
{
    Trellis,
    Arch,
    Cage,
    Fence
}
