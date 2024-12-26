using IP.Geolocation.Interfaces;
using System.Net;
using System.Text.Json.Serialization;

namespace IP.Geolocation;

internal class Geoplugin_Return : IIPGeolocationResult
{
#pragma warning disable IDE1006 // Naming Styles
	[JsonPropertyName("geoplugin_status")]
	public dynamic? Status { get; set; }

	[JsonPropertyName("geoplugin_city")]
	public string? City { get; set; }

	[JsonPropertyName("geoplugin_regionName")]
	public string? State { get; set; }

	[JsonPropertyName("geoplugin_regionCode")]
	public string? CountryCode { get; set; }

	[JsonPropertyName("geoplugin_countryName")]
	public string? Country { get; set; }

	//public string? geoplugin_areaCode { get; set; }
	//public string geoplugin_dmaCode { get; set; }
	//public string? geoplugin_countryCode { get; set; }
	//public string geoplugin_inEU { get; set; }
	//public string geoplugin_euVATrate { get; set; }
	//public string geoplugin_continentCode { get; set; }
	//public string? geoplugin_continentName { get; set; }

	[JsonPropertyName("geoplugin_latitude")]
	public dynamic? Latitude { get; set; }

	[JsonPropertyName("geoplugin_longitude")]
	public dynamic? Longitude { get; set; }

	//public string? geoplugin_locationAccuracyRadius { get; set; }

	[JsonPropertyName("geoplugin_timezone")]
	public string? Timezone { get; set; }

	//public string? geoplugin_currencyCode { get; set; }
	//public string? geoplugin_currencySymbol { get; set; }
	//public string? geoplugin_currencySymbol_UTF8 { get; set; }
	//public string? geoplugin_currencyConverter { get; set; }
	public DateTime? LastQuery { get; set; }

	public string? Zip { get; set; }
	public string? ISP { get; set; }
	public string? Org { get; set; }
	public bool? Mobile { get; set; }
	public string? Others { get; set; }

#pragma warning restore IDE1006 // Naming Styles
}
