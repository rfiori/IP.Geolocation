using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;

namespace IP.Geolocation.Results;

internal class IPStack_Result : IIPGeolocationResult
{
    // http://api.ipstack.com/167.250.0.38?access_key=d6eaff542aa81fd46f8df439161427cb

    /*
           {
            "ip":"167.250.0.38",
            "type":"ipv4",
            "continent_code":"SA",
            "continent_name":"South America",
            "country_code":"BR",
            "country_name":"Brazil",
            "region_code":"MG",
            "region_name":"Minas Gerais",
            "city":"Belo Horizonte",
            "zip":"30000",
            "latitude":-19.8975,
            "longitude":-43.9625,
            "location":
                {
                "geoname_id":3470127,
                "capital":"Bras\u00edlia",
                "languages":[
                    {
                    "code":"pt",
                    "name":"Portuguese",
                    "native":"Portugu\u00eas"
                    }
                ],
                "country_flag":"http:\\assets.ipstack.com\/flags\/br.svg",
                //"country_flag_emoji":"\ud83c\udde7\ud83c\uddf7",
                //"country_flag_emoji_unicode":"U+1F1E7 U+1F1F7",
                "calling_code":"55",
                //"is_eu":false
                }
            }
        */

    private readonly IPStack_Return geo_Return;

    public IPStack_Result(IPStack_Return ipstack_Return)
    {
        geo_Return = ipstack_Return;
    }


    public string Status
    {
        get { return string.Empty; }
    }

    public DateTime? LastQuery
    {
        get { return geo_Return.LastQuery; }
    }

    public string Country
    {
        get { return geo_Return.country_name; }
    }

    public string CountryCode
    {
        get { return geo_Return.country_code; }
    }

    public string State
    {
        get { return $"{geo_Return.region_name} - {geo_Return.region_code}"; }
    }

    public string City
    {
        get { return geo_Return.city; }
    }

    public string Zip
    {
        get { return geo_Return.zip; }
    }

    public string Latitude
    {
        get { return geo_Return.latitude; }
    }

    public string Longitude
    {
        get { return geo_Return.longitude; }
    }

    public string Timezone
    {
        get { return string.Empty; }
    }

    public string ISP
    {
        get { return string.Empty; }
    }

    public string Org
    {
        get { return string.Empty; }
    }

    public bool? Mobile
    {
        get { return null; }
    }

    public string Others
    {
        get { return $"IP: {geo_Return.ip}"; }
    }
}
