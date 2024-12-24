using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;

namespace IP.Geolocation.Results;

internal class IPApi_Result : IIPGeolocationResult
{
	//http://ip-api.com/json/167.250.0.38?fields=status,message,country,countryCode,regionName,city,zip,lat,lon,timezone,isp,org,mobile

	/* {
            "city":"Belo Horizonte",
            "country":"Brazil",
            "countryCode":"BR",
            "isp":"Vianet Ltda ME",
            "lat":-19.8975,
            "lon":-43.9625,
            "mobile":false,
            "org":"Vianet Ltda ME",
            "regionName":"Minas Gerais",
            "status":"success",
            "timezone":"America/Sao_Paulo",
            "zip":"30000"
            } */

	private readonly IPApi_Return geo_Return;

	public IPApi_Result(IPApi_Return objReturn)
	{
		geo_Return = objReturn;
	}


	public string City
	{
		get { return geo_Return.city; }
	}

	public string Country
	{
		get { return geo_Return.country; }
	}

	public string CountryCode
	{
		get { return geo_Return.countryCode; }
	}

	public string ISP
	{
		get { return geo_Return.isp; }
	}

	public DateTime? LastQuery
	{
		get { return geo_Return.LastQuery; }
	}

	public string Latitude
	{
		get { return geo_Return.lat; }
	}

	public string Longitude
	{
		get { return geo_Return.lon; }
	}

	public bool? Mobile
	{
		get { return geo_Return.mobile; }
	}

	public string Org
	{
		get { return geo_Return.org; }
	}

	public string Others
	{
		get { return string.Empty; }
	}

	public string Othres
	{
		get { return string.Empty; }
	}

	public string State
	{
		get { return geo_Return.regionName; }
	}

	public string Status
	{
		get { return geo_Return.status; }
	}

	public string Timezone
	{
		get { return geo_Return.timezone; }
	}

	public string Zip
	{
		get { return geo_Return.zip; }
	}
}
