using IP.Geolocation.Interfaces;
using System.Text.Json.Serialization;

namespace IP.Geolocation.APIReturns;

/*
 * exemple api return
 * 
{
  "geoplugin_request":"179.162.174.33",
  "geoplugin_status":200,
  "geoplugin_delay":"2ms",
  "geoplugin_credit":"Some of the returned data includes GeoLite2 data created by MaxMind, available from <a href='https:\/\/www.maxmind.com'>https:\/\/www.maxmind.com<\/a>.",
  "geoplugin_city":"Belo Horizonte",
  "geoplugin_region":"Minas Gerais",
  "geoplugin_regionCode":"MG",
  "geoplugin_regionName":"Minas Gerais",
  "geoplugin_areaCode":"",
  "geoplugin_dmaCode":"",
  "geoplugin_countryCode":"BR",
  "geoplugin_countryName":"Brazil",
  "geoplugin_inEU":0,
  "geoplugin_euVATrate":false,
  "geoplugin_continentCode":"SA",
  "geoplugin_continentName":"South America",
  "geoplugin_latitude":"-19.9221",
  "geoplugin_longitude":"-43.9347",
  "geoplugin_locationAccuracyRadius":"20",
  "geoplugin_timezone":"America\/Sao_Paulo",
  "geoplugin_currencyCode":"BRL",
  "geoplugin_currencySymbol":"R$",
  "geoplugin_currencySymbol_UTF8":"R$",
  "geoplugin_currencyConverter":6.7373
}
 */

internal class GeopluginReturn : IIPGeolocationResult
{
	string? _status;

	[JsonPropertyName("geoplugin_status")]
	[JsonConverter(typeof(StringOrIntConverter))]
	public string? Status
	{
		get => _status;
		set => _status = value! == "200" ? "success" : value;
	}

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

	public string? Zip { get; set; }
	public string? ISP { get; set; }
	public string? Org { get; set; }
	public bool? Mobile { get; set; }
	public string? Others { get; set; }
	public DateTime? LastQuery { get; } = DateTime.UtcNow;
}
