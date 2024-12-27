using IP.Geolocation.Interfaces;
using System.Text.Json.Serialization;

namespace IP.Geolocation.APIReturns;

internal class GeopluginReturn : IIPGeolocationResult
{
#pragma warning disable IDE1006 // Naming Styles
    [JsonPropertyName("geoplugin_status")]
    public dynamic? Status { get; set; }

    [JsonPropertyName("geoplugin_city")]
    public string? City { get; set; }

    [JsonPropertyName("geoplugin_regionName")]
    public string? State { get; set; }

    [JsonPropertyName("geoplugin_countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("geoplugin_countryName")]
    public string? Country { get; set; }

    [JsonPropertyName("geoplugin_latitude")]
    public dynamic? Latitude { get; set; }

    [JsonPropertyName("geoplugin_longitude")]
    public dynamic? Longitude { get; set; }

    [JsonPropertyName("geoplugin_timezone")]
    public string? Timezone { get; set; }

    public DateTime? LastQuery { get; set; }

    public string? Zip { get; set; }
    public string? ISP { get; set; }
    public string? Org { get; set; }
    public bool? Mobile { get; set; }
    public string? Others { get; set; }

    //public string? geoplugin_locationAccuracyRadius { get; set; }
    //public string? geoplugin_areaCode { get; set; }
    //public string geoplugin_dmaCode { get; set; }
    //public string? geoplugin_countryCode { get; set; }
    //public string geoplugin_inEU { get; set; }
    //public string geoplugin_euVATrate { get; set; }
    //public string geoplugin_continentCode { get; set; }
    //public string? geoplugin_continentName { get; set; }
    //public string? geoplugin_currencyCode { get; set; }
    //public string? geoplugin_currencySymbol { get; set; }
    //public string? geoplugin_currencySymbol_UTF8 { get; set; }
    //public string? geoplugin_currencyConverter { get; set; }

#pragma warning restore IDE1006 // Naming Styles
}
