namespace IP.Geolocation.Interfaces;

public interface IIPGeolocationResult
{
    public dynamic? Status { get; }

    public DateTime? LastQuery { get; }

    public string? Country { get; }

    public string? CountryCode { get; }

    public string? State { get; }

    public string? City { get; }

    public string? Zip { get; }

    public dynamic? Latitude { get; }

    public dynamic? Longitude { get; }

    public string? Timezone { get; }

    public string? ISP { get; }

    public string? Org { get; }

    public bool? Mobile { get; }

    public string? Others { get; }
}
