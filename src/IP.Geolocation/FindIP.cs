using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;
using System.Net.Http.Headers;

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

    //------------------------------------------------------------------------//

    public static async Task<IIPGeolocationResult?> GetIPGeolocationAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
    {
        if (string.IsNullOrEmpty(ip) || ip.Contains("localhost") || ip.Contains("::1") || ip.Contains("- "))
            return new IPGeoLocationResult() { Status = $"IP:{ip} Not detect or localhost" };

        // Get Geo Location info
        var retAPI = await Get_IPAPI_Async(ip, timeOut);   // 1th Try

        if (!ConfirmDataRequest(retAPI))
            retAPI = await getFromGeopluginAsync(ip, timeOut); // 2th Try

        if (!ConfirmDataRequest(retAPI))
            retAPI = await getFromIPInfoAsync(ip, timeOut); // 3th Try

        return retAPI;
    }

    //------------------------------------------------------------------------//

    private static bool ConfirmDataRequest(IIPGeolocationResult? geoResult)
    {
        if (geoResult == null || string.IsNullOrEmpty(geoResult!.State) || string.IsNullOrEmpty(geoResult.Country))
            return false;

        return true;
    }

    //------------------------------------------------------------------------//

    private static async Task<string?> CallAPI(string apiUrl)
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
