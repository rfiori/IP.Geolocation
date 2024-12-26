using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;

namespace IP.Geolocation.APIReturns;

internal class IPStack_Return : IIPGeolocationResult
{
    public string? ip { get; set; }
    public DateTime? LastQuery { get; set; }
    public string? type { get; set; }
    public string? continent_code { get; set; }
    public string? continent_name { get; set; }
    public string? country_code { get; set; }
    public string? country_name { get; set; }
    public string? region_code { get; set; }
    public string? region_name { get; set; }
    public string? city { get; set; }

    public string? City => throw new NotImplementedException();

    public string? zip { get; set; }

    public string? Zip => throw new NotImplementedException();

    public string? latitude { get; set; }

    public dynamic? Latitude => throw new NotImplementedException();

    public dynamic? longitude { get; set; }

    public dynamic? Longitude => throw new NotImplementedException();

    public Location? location { get; set; }

    public dynamic? Status => throw new NotImplementedException();

    public string? Country => throw new NotImplementedException();

    public string? CountryCode => throw new NotImplementedException();

    public string? State => throw new NotImplementedException();

    public string? Timezone => throw new NotImplementedException();

    public string? ISP => throw new NotImplementedException();

    public string? Org => throw new NotImplementedException();

    public bool? Mobile => throw new NotImplementedException();

    public string? Others => throw new NotImplementedException();

    //public IIPGeolocationResult Result()
    //{
    //    return new IPStack_Result(this);
    //}
}

internal class Location
{
    public int geoname_id { get; set; }
    public string capital { get; set; }
    public Language[] languages { get; set; }
    public string country_flag { get; set; }
    //public string country_flag_emoji { get; set; }
    //public string country_flag_emoji_unicode { get; set; }
    public string calling_code { get; set; }
    //public bool is_eu { get; set; }
}

internal class Language
{
    public string code { get; set; }
    public string name { get; set; }
    public string native { get; set; }
}
