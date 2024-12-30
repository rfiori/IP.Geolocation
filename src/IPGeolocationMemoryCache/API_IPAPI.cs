using IPGeolocationMemoryCache.APIReturns;
using IPGeolocationMemoryCache.Interfaces;
using System.Text.Json;

namespace IPGeolocationMemoryCache
{
	public partial class IpGeoLocation
	{
		//--- site http://www.ip-api.com
		const string IpApi_URL = "http://ip-api.com/json/";

		private static async Task<IIPGeolocationResult?> GetFromIPAPIAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
		{
			try
			{
				var content = await CallAPI($"{IpApi_URL}{ip}");
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
