using System.Text.Json.Serialization;

namespace HomesteadManagerApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SunPreference
{
    FullSun,
    PartialSun,
    FullShade
}
