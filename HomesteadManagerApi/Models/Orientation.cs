using System.Text.Json.Serialization;

namespace HomesteadManagerApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Orientation
{
    NorthSouth,
    EastWest
}
