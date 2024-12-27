using IP.Geolocation.Interfaces;
using System.Text.Json.Serialization;

namespace IP.Geolocation.APIReturns;

/*
 * Exemple api return
 * 
 {
    "ip": "179.162.174.33",
    "hostname": "179.162.174.33.dynamic.adsl.gvt.net.br",
    "city": "Belo Horizonte",
    "region": "Minas Gerais",
    "country": "BR",
    "loc": "-19.9208,-43.9378",
    "org": "AS18881 TELEFÔNICA BRASIL S.A",
    "postal": "30000-000",
    "timezone": "America/Sao_Paulo",
    "readme": "https://ipinfo.io/missingauth"
  }
 */

internal class IPInfoReturn : IIPGeolocationResult
{
    public dynamic? Status { get; set; }

    public string? Country { get; set; }

    [JsonPropertyName("country")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("region")]
    public string? State { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("postal")]
    public string? Zip { get; set; }

    [JsonPropertyName("loc")]
    public dynamic? Latitude { get; set; }

    //[JsonPropertyName("loc")]
    public dynamic? Longitude { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("hostname")]
    public string? ISP { get; set; }

    [JsonPropertyName("org")]
    public string? Org { get; set; }

    public bool? Mobile { get; set; }

    //[Json PropertyName("loc")]
    public string? Others { get; set; }

    public DateTime? LastQuery { get; } = DateTime.UtcNow;
}
