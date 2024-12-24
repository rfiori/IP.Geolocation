using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;

namespace IP.Geolocation;

internal class Geoplugin_Return
{
#pragma warning disable IDE1006 // Naming Styles

	public string? geoplugin_request { get; set; }
	public string? geoplugin_status { get; set; }
	public string? geoplugin_delay { get; set; }
	public string? geoplugin_city { get; set; }
	public string? geoplugin_region { get; set; }
	public string? geoplugin_regionCode { get; set; }
	public string? geoplugin_regionName { get; set; }
	public string? geoplugin_areaCode { get; set; }
	//public string geoplugin_dmaCode { get; set; }
	public string? geoplugin_countryCode { get; set; }
	public string? geoplugin_countryName { get; set; }
	//public string geoplugin_inEU { get; set; }
	//public string geoplugin_euVATrate { get; set; }
	//public string geoplugin_continentCode { get; set; }
	public string? geoplugin_continentName { get; set; }
	public string? geoplugin_latitude { get; set; }
	public string? geoplugin_longitude { get; set; }
	public string? geoplugin_locationAccuracyRadius { get; set; }
	public string? geoplugin_timezone { get; set; }
	public string? geoplugin_currencyCode { get; set; }
	public string? geoplugin_currencySymbol { get; set; }
	public string? geoplugin_currencySymbol_UTF8 { get; set; }
	public string? geoplugin_currencyConverter { get; set; }
	public DateTime? LastQuery { get; set; }

#pragma warning restore IDE1006 // Naming Styles

	public IIPGeolocationResult Result()
	{
		return new Geoplugin_Result(this);
	}
}
