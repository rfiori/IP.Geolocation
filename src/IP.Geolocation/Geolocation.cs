using IP.Geolocation.APIReturns;
using IP.Geolocation.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IP.Geolocation;

public class Geolocation
{
	private const int TIMEOUT_SEC = 1;
	private const int TIMEOUT_MILESSEC = TIMEOUT_SEC * 1000;

	//--- site http://www.ip-api.com
	private const string API_IpApi_URL = "http://ip-api.com/json/";

	//--- site http://www.geoplugin.net
	private const string API_Geoplugin_URL = "http://geoplugin.net/json.gp?ip=";

	//--- site http://api.ipstack.com/167.250.0.38?access_key=d6eaff542aa81fd46f8df439161427cb
	private const string API_IPStack_URL = "http://api.ipstack.com/";

	//------------------------------------------------------------------------//

	public static async Task<IIPGeolocationResult?> GetIPGeolocationAsync(string IP, int timeOut = TIMEOUT_MILESSEC)
	{
		if (string.IsNullOrEmpty(IP) || IP.Contains("localhost") || IP.Contains("::1") || IP.Contains("- "))
		{
#if DEBUG
			IP = "186.206.144.86"; // Aleatory IP for debug mode
#else
                return new IIPGeolocationResult(){ Status = $"IP:{IP} Not detect";
#endif
		}

		// Get Geo Location info
		var ret = await GetFromIP_API_Async(IP, timeOut); // 1th Try

		if (ret == null || !chkResultStateCity(ret))
		{
			ret = getFromGeoplugin(IP, timeOut); // 2th Try
			if (ret == null || !chkResultStateCity(ret))
				ret = getFromIPStack(IP, "d6eaff542aa81fd46f8df439161427cb", timeOut); // 3th Try
		}
		return ret;
	}

	private static bool chkResultStateCity(IIPGeolocationResult geoResult)
	{
		var ret = true;

		if (string.IsNullOrEmpty(geoResult.State) || string.IsNullOrEmpty(geoResult.City))
			ret = false;
		return ret;
	}

	//------------------------------------------------------------------------//

	private static async Task<IIPGeolocationResult?> GetFromIP_API_Async(string IP, int timeOut = TIMEOUT_MILESSEC)
	{
		using var client = new HttpClient();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		client.Timeout = new TimeSpan(0, 0, TIMEOUT_SEC);
		try
		{
			var response = await client.GetAsync($"{API_IpApi_URL}{IP}?fields=status,message,country,countryCode,regionName,city,zip,lat,lon,timezone,isp,org,mobile");

			//executing within timeout.
			//var response = response.Result;

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var IpApi_ret = JsonSerializer.Deserialize<IPApi_Return>(content) ?? new IPApi_Return();
				IpApi_ret.LastQuery = DateTime.UtcNow;
				return IpApi_ret.Result();
			}
			else
				return null;
		}
		catch { return null; }
	}

	private static IIPGeolocationResult? getFromGeoplugin(string IP, int timeOut = TIMEOUT_MILESSEC)
	{
		using (var client = new HttpClient())
		{
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.Timeout = new System.TimeSpan(0, 0, TIMEOUT_SEC);
			try
			{
				var task = client.GetAsync(API_Geoplugin_URL + IP);
				//var firstTaks = Task.WhenAny(task, Task.Delay(timeOut));

				//if (firstTaks == task)
				{
					//executing within timeout.
					var response = task.Result;

					if (response.IsSuccessStatusCode)
					{
						var dataObjects = response.Content.ReadAsStringAsync().Result;
						var ret = JsonSerializer.Deserialize<Geoplugin_Return>(dataObjects);
						ret.LastQuery = DateTime.Now;
						return ret.Result();
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
						return ret.Result();
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
