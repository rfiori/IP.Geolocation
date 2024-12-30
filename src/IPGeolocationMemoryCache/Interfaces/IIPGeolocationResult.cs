namespace IPGeolocationMemoryCache.Interfaces;

public interface IIPGeolocationResult
{
    /// <summary>
    /// Some API return the Status in call result. Else the Status is "success" when  <see cref="Country"/> contain any data.
    /// </summary>
    public string? Status { get; }
    /// <summary>
    /// Date time that last query.
    /// </summary>
    public DateTime? LastQuery { get; }
    /// <summary>
    /// Country name.
    /// </summary>
    public string? Country { get; }
    /// <summary>
    /// Country code.
    /// </summary>
    public string? CountryCode { get; }
    /// <summary>
    /// State name.
    /// </summary>
    public string? State { get; }
    /// <summary>
    /// City name.
    /// </summary>
    public string? City { get; }
    /// <summary>
    /// Initial city zip code
    /// </summary>
    public string? Zip { get; }
    /// <summary>
    /// Latituda number.
    /// </summary>
    public dynamic? Latitude { get; }
    /// <summary>
    /// Longitude number.
    /// </summary>
    public dynamic? Longitude { get; }
    /// <summary>
    /// Retion timezone.
    /// </summary>
    public string? Timezone { get; }
    /// <summary>
    /// ISP name.
    /// </summary>
    public string? ISP { get; }
    /// <summary>
    /// Organization name.
    /// </summary>
    public string? Org { get; }
    /// <summary>
    /// Is true when API identify IP is mobile.
    /// </summary>
    public bool? Mobile { get; }
    /// <summary>
    /// Any additional data.
    /// </summary>
    public string? Others { get; set; }
}
