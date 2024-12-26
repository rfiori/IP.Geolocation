using IP.Geolocation.Interfaces;

namespace IP.Geolocation.Results;

internal class Geoplugin_Result : IIPGeolocationResult
{
    // http://www.geoplugin.net/json.gp?ip=167.250.0.38

    /*{
          "geoplugin_request":"167.250.0.38",
          "geoplugin_status":200,
          "geoplugin_delay":"1ms",
          "geoplugin_city":"Belo Horizonte",
          "geoplugin_region":"Minas Gerais",
          "geoplugin_regionCode":"MG",
          "geoplugin_regionName":"Minas Gerais",
          "geoplugin_areaCode":"",
          //"geoplugin_dmaCode":"",
          "geoplugin_countryCode":"BR",
          "geoplugin_countryName":"Brazil",
          //"geoplugin_inEU":0,
          //"geoplugin_euVATrate":false,
          //"geoplugin_continentCode":"SA",
          "geoplugin_continentName":"South America",
          "geoplugin_latitude":"-19.8993",
          "geoplugin_longitude":"-43.957",
          "geoplugin_locationAccuracyRadius":"10",
          "geoplugin_timezone":"America\/Sao_Paulo",
          "geoplugin_currencyCode":"BRL",
          "geoplugin_currencySymbol":"R$",
          "geoplugin_currencySymbol_UTF8":"R$",
          "geoplugin_currencyConverter":3.9231
        }*/

    private readonly Geoplugin_Return geo_Return;

    public Geoplugin_Result(Geoplugin_Return geoplugin)
    {
        geo_Return = geoplugin;
    }


    public string Status
    {
        get { return geo_Return.geoplugin_status.ToString(); }
    }

    public DateTime? LastQuery
    {
        get { return geo_Return.LastQuery; }
    }

    public string Country
    {
        get { return geo_Return.geoplugin_countryName; }
    }

    public string CountryCode
    {
        get { return geo_Return.geoplugin_countryCode; }
    }

    public string State
    {
        get { return $"{geo_Return.geoplugin_regionName} - {geo_Return.geoplugin_regionCode}"; }
    }

    public string City
    {
        get { return geo_Return.geoplugin_city; }
    }

    public string Zip
    {
        get { return geo_Return.geoplugin_areaCode; }
    }

    public string Latitude
    {
        get { return geo_Return.geoplugin_latitude; }
    }

    public string Longitude
    {
        get { return geo_Return.geoplugin_longitude; }
    }

    public string Timezone
    {
        get { return geo_Return.geoplugin_timezone; }
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
        get
        {
            return $"Continent-Name:{geo_Return.geoplugin_continentName}; " +
               $"Country:{geo_Return.geoplugin_countryName}; " +
               $"Currency-Code:{geo_Return.geoplugin_currencyCode}; " +
               $"Currency-Symbol:{geo_Return.geoplugin_currencySymbol}; " +
               $"Currency-Converter:{geo_Return.geoplugin_currencyConverter}; " +
               $"Delay:{geo_Return.geoplugin_delay}";
        }
    }
}
