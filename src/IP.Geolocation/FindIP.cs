using IP.Geolocation.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IP.Geolocation;

//------------------------------------------------------------------------//
// Some API to find geolocation
// http://www.ip-api.com
// http://www.geoplugin.net
// https://ipinfo.io
// http://api.ipstack.com Need API Key
// https://www.ip2location.io Need API Key
// https://ipgeolocation.io Need API Key
// https://console.hgbrasil.com/documentation/geoip Need API Key
//------------------------------------------------------------------------//

public partial class FindIP
{
    const int TIMEOUT_SEC = 2;
    const int TIMEOUT_MILESSEC = TIMEOUT_SEC * 1000;
    const string CHACHE_KEY = "#IP";

    private readonly IMemoryCache _cache;


    //------------------------------------------------------------------------//

    public FindIP(IMemoryCache memoryCache)
    {
        _cache = memoryCache;
    }

    //------------------------------------------------------------------------//

    public async Task<IIPGeolocationResult?> GetIPGeolocationAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
    {
        if (string.IsNullOrEmpty(ip) || ip.Contains("localhost") || ip.Contains("::1") || ip.Contains("- "))
            return new IPGeoLocationResult() { Status = $"IP:{ip} Not detect or localhost" };

        //Check cache before
        if (_cache != null)
            return RequestInCache(ip);

        // Get Geo Location info
        var retAPI = await Get_IPAPI_Async(ip, timeOut);   // 1th Try

        if (!ConfirmDataRequest(retAPI))
            retAPI = await getFromGeopluginAsync(ip, timeOut); // 2th Try

        if (!ConfirmDataRequest(retAPI))
            retAPI = await getFromIPInfoAsync(ip, timeOut); // 3th Try

        if (_cache != null)
            AddCache(retAPI, ip);

        return retAPI;
    }

    //------------------------------------------------------------------------//

    private IPGeoLocationResult? RequestInCache(string ip)
    {
        IPGeoLocationResult? geoIpJson = null;
        var key = $"{CHACHE_KEY}{ip}";

        if (_cache.TryGetValue(key, out string? outData))
            geoIpJson = JsonSerializer.Deserialize<IPGeoLocationResult>(outData!);
        return geoIpJson ?? null;
    }

    private void AddCache(IIPGeolocationResult geoIpJson, string ip)
    {
        var key = $"{CHACHE_KEY}{ip}";
        string jsonObj = JsonSerializer.Serialize(geoIpJson);

        if (_cache.TryGetValue(key, out string? outData))
        {
            //geoIpJson = JsonSerializer.Deserialize<IPGeoLocationResult>(outData!);
            if (outData != null)
                return;

            _cache.Set(key, jsonObj, TimeSpan.FromMinutes(10));
        }
    }

    private bool ConfirmDataRequest(IIPGeolocationResult? geoResult)
    {
        if (geoResult == null || string.IsNullOrEmpty(geoResult!.State) || string.IsNullOrEmpty(geoResult.Country))
            return false;

        return true;
    }

    //------------------------------------------------------------------------//

    private async Task<string?> CallAPI(string apiUrl)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.Timeout = new TimeSpan(0, 0, TIMEOUT_SEC);
        try
        {
            var request = await client.GetAsync($"{apiUrl}");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                return content;
            }
            else
                return null;
        }
        catch { return null; }
    }
}
