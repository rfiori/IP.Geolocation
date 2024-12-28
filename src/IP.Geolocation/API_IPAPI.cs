﻿using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;
using System.Text.Json;

namespace IP.Geolocation
{
	public partial class FindIP
	{
		//--- site http://www.ip-api.com
		const string API_IpApi_URL = "http://ip-api.com/json/";

		private static async Task<IIPGeolocationResult?> Get_IPAPI_Async(string ip, int timeOut = TIMEOUT_MILESSEC)
		{
			try
			{
				var content = await CallAPI($"{API_IpApi_URL}{ip}");
				if (!string.IsNullOrEmpty(content))
				{
					var IpApi_ret = JsonSerializer.Deserialize<IPApiReturn>(content);
					return IpApi_ret;
				}
				else { return null; }
			}
			catch { return null; }

		}
	}
}