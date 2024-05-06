namespace HomesteadManagerApi.Models;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Season
{
    Winter,
    Spring,
    Sun,
    Fall
}
