using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;
using System.Text.Json;

namespace IP.Geolocation
{
    public partial class FindIP
    {
        private async static Task<IIPGeolocationResult?> getFromIPInfoAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
        {
            // api https://ipinfo.io/8.8.8.8/json
            const string API_Geoplugin_URL = "https://ipinfo.io";
            try
            {
                var content = await CallAPI($"{API_Geoplugin_URL}/{ip}/json");
                if (!string.IsNullOrEmpty(content))
                {
                    var geoP_ret = JsonSerializer.Deserialize<IPInfoReturn>(content);
                    return geoP_ret;
                }
                else
                    return null;
            }
            catch { return null; }
        }
    }
}
