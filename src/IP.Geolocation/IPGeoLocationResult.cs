using IP.Geolocation.Interfaces;

namespace IP.Geolocation;

public class IPGeoLocationResult : IIPGeolocationResult
{
    public string? Status { get; set; }
    public DateTime? LastQuery { get; set; }
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public dynamic? Latitude { get; set; }
    public dynamic? Longitude { get; set; }
    public string? Timezone { get; set; }
    public string? ISP { get; set; }
    public string? Org { get; set; }
    public bool? Mobile { get; set; }
    public string? Others { get; set; }
}
