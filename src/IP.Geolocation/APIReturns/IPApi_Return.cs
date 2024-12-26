using IP.Geolocation.Interfaces;
using System.Text.Json.Serialization;

namespace IP.Geolocation.APIReturns;

internal class IPApi_Return : IIPGeolocationResult
{
#pragma warning disable IDE1006 // Naming Styles

    [JsonPropertyName("status")]
    public dynamic? Status { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("regionName")]
    public string? State { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("lat")]
    public dynamic? Latitude { get; set; }

    [JsonPropertyName("lon")]
    public dynamic? Longitude { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("isp")]
    public string? ISP { get; set; }

    [JsonPropertyName("org")]
    public string? Org { get; set; }

    [JsonPropertyName("mobile")]
    public bool? Mobile { get; set; }

    [JsonIgnore]
    public DateTime? LastQuery { get; } = DateTime.UtcNow;

    [JsonIgnore]
    public string? Others { get; set; }

#pragma warning restore IDE1006 // Naming Styles

    //public IIPGeolocationResult Result()
    //{
    //    return new IPApi_Result(this);
    //}
}
