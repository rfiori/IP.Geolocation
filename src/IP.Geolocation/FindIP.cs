using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IP.Geolocation;

//------------------------------------------------------------------------//
// Use API to find geolocation
// http://www.ip-api.com
// http://www.geoplugin.net
//------------------------------------------------------------------------//

public partial class FindIP
{
    const int TIMEOUT_SEC = 2;
    const int TIMEOUT_MILESSEC = TIMEOUT_SEC * 1000;

    //--- site http://api.ipstack.com/167.250.0.38?access_key=d6eaff542aa81fd46f8df439161427cb
    const string API_IPStack_URL = "http://api.ipstack.com/";

    //------------------------------------------------------------------------//

    public static async Task<IIPGeolocationResult?> GetIPGeolocationAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
    {
        if (string.IsNullOrEmpty(ip) || ip.Contains("localhost") || ip.Contains("::1") || ip.Contains("- "))
            return new IPGeoLocationResult() { Status = $"IP:{ip} Not detect" };

        // Get Geo Location info
        var retAPI = await Get_IPAPI_Async(ip, timeOut); // 1th Try

        if (!ConfirmDataRequest(retAPI))
        {
            retAPI = await getFromGeopluginAsync(ip, timeOut); // 2th Try
            //if (!ConfirmDataRequest(retAPI))
            //    ret_IPAPI = getFromIPStack(ip, "d6eaff542aa81fd46f8df439161427cb", timeOut); // 3th Try
        }
        return retAPI;
    }

    //------------------------------------------------------------------------//

    private static bool ConfirmDataRequest(IIPGeolocationResult? geoResult)
    {
        return false;
        var ret = true;
        if (geoResult == null || string.IsNullOrEmpty(geoResult!.State) || string.IsNullOrEmpty(geoResult.City))
            ret = false;
        return ret;
    }

    //------------------------------------------------------------------------//

    private static async Task<string?> CallAPI(string apiUrl, string ip)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.Timeout = new TimeSpan(0, 0, TIMEOUT_SEC);
        try
        {
            var request = await client.GetAsync($"{apiUrl}{ip}");

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

    private static async Task<IIPGeolocationResult?> getFromGeopluginAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
    {
        //--- site http://www.geoplugin.net
        const string API_Geoplugin_URL = "http://geoplugin.net/json.gp?ip=";

        try
        {
            var content = await CallAPI(API_Geoplugin_URL, ip);
            if (!string.IsNullOrEmpty(content))
            {
                var geoP_ret = JsonSerializer.Deserialize<Geoplugin_Return>(content);
                return geoP_ret;
            }
            else
                return null;
        }
        catch { return null; }
    }

    private static IIPGeolocationResult? getFromIPStack(string IP, string API_Key, int timeOut = TIMEOUT_MILESSEC)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new System.TimeSpan(0, 0, TIMEOUT_SEC);
            try
            {
                var task = client.GetAsync(API_IPStack_URL + IP + "?access_key=" + API_Key);
                //var firstTaks = Task.WhenAny(task, Task.Delay(timeOut));

                //if (firstTaks == task)
                {
                    //executing within timeout.
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var dataObjects = response.Content.ReadAsStringAsync().Result;
                        var ret = JsonSerializer.Deserialize<IPStack_Return>(dataObjects);
                        ret.LastQuery = DateTime.Now;
                        return ret;
                    }
                    else
                        return null;
                }
                //else
                //return null; // timeout
            }
            catch { return null; }
        }
    }
}
