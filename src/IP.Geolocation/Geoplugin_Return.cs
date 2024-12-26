using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;
using System.Text.Json.Serialization;

namespace IP.Geolocation;

internal class Geoplugin_Return : IIPGeolocationResult
{
#pragma warning disable IDE1006 // Naming Styles

    [JsonPropertyName("geoplugin_status")]
    public string? Status { get; set; }

    [JsonPropertyName("geoplugin_city")]
    public string? City { get; set; }

    [JsonPropertyName("geoplugin_regionName")]
    public string? State { get; set; }

    [JsonPropertyName("geoplugin_regionCode")]
    public string? CountryCode {  get; set; }

    [JsonPropertyName("geoplugin_countryName")]
    public string? Country {  get; set; }

xxx    public string? geoplugin_areaCode { get; set; }
    //public string geoplugin_dmaCode { get; set; }
    public string? geoplugin_countryCode { get; set; }
    //public string geoplugin_inEU { get; set; }
    //public string geoplugin_euVATrate { get; set; }
    //public string geoplugin_continentCode { get; set; }
    public string? geoplugin_continentName { get; set; }
    public string? geoplugin_latitude { get; set; }
    public double? Latitude => throw new NotImplementedException();
    public string? geoplugin_longitude { get; set; }
    public double? Longitude => throw new NotImplementedException();
    public string? geoplugin_locationAccuracyRadius { get; set; }
    public string? geoplugin_timezone { get; set; }
    public string? Timezone => throw new NotImplementedException();
    public string? geoplugin_currencyCode { get; set; }
    public string? geoplugin_currencySymbol { get; set; }
    public string? geoplugin_currencySymbol_UTF8 { get; set; }
    public string? geoplugin_currencyConverter { get; set; }
    public DateTime? LastQuery { get; set; }

    public string? Zip => throw new NotImplementedException();
    public string? ISP => throw new NotImplementedException();
    public string? Org => throw new NotImplementedException();
    public bool? Mobile => throw new NotImplementedException();
    public string? Others => throw new NotImplementedException();

#pragma warning restore IDE1006 // Naming Styles

    //public IIPGeolocationResult Result()
    //{
    //    return new Geoplugin_Result(this);
    //}
}
