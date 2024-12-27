﻿using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;
using System.Text.Json;

namespace IP.Geolocation
{
    public partial class FindIP
    {
        private static async Task<IIPGeolocationResult?> getFromGeopluginAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
        {
            //--- site http://www.geoplugin.net
            const string API_Geoplugin_URL = "http://geoplugin.net/json.gp?ip=";
            try
            {
                var content = await CallAPI(API_Geoplugin_URL, ip);
                if (!string.IsNullOrEmpty(content))
                {
                    var geoP_ret = JsonSerializer.Deserialize<GeopluginReturn>(content);
                    return geoP_ret;
                }
                else
                    return null;
            }
            catch { return null; }
        }
    }
}