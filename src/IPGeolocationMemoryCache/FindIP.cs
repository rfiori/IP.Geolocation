using IPGeolocationMemoryCache.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IPGeolocationMemoryCache;

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

	private readonly IMemoryCache? _cache;
	private readonly TimeSpan _timeExpiration;

	//------------------------------------------------------------------------//

	/// <summary>
	/// Create a instance for Find IP.
	/// </summary>
	/// <param name="memoryCache">Obj MemoryCache to use for cache IP data.</param>
	/// <param name="cacheExpirationInMinutes">Cache expiration em minutes. Default 10 minutes to expire.</param>
	public FindIP(IMemoryCache? memoryCache, int cacheExpirationInMinutes = 10)
	{
		_cache = memoryCache;
		_timeExpiration = TimeSpan.FromMinutes(cacheExpirationInMinutes);
	}

	//------------------------------------------------------------------------//

	/// <summary>
	/// Get IP geolocation data.
	/// </summary>
	/// <param name="ip">IP address.</param>
	/// <param name="timeOut">API connection timeout.</param>
	/// <returns></returns>
	public async Task<IIPGeolocationResult?> GetIPGeolocationAsync(string ip, int timeOut = TIMEOUT_MILESSEC)
	{
		if (string.IsNullOrEmpty(ip) || ip.Contains("localhost") || ip.Contains("::1") || ip.Contains("- "))
			return new IPGeoLocationResult() { Status = $"IP:{ip} Not detect or localhost" };

		//Check cache before and try get json data.
		if (_cache != null)
		{
			var ret = RequestInCache(ip);
			if (ret != null && !string.IsNullOrEmpty(ret!.CountryCode))
				return ret;
		}

		// Get IP geolocation info
		var retAPI = await GetFromIPAPIAsync(ip, timeOut);   // 1th Try
		if (!ConfirmDataRequest(retAPI))
			retAPI = await GetGeopluginAsync(ip, timeOut); // 2th Try
		else if (!ConfirmDataRequest(retAPI))
			retAPI = await GetFromIPInfoAsync(ip, timeOut); // 3th Try

		if (_cache != null)
			AddCache(retAPI!, ip);

		return retAPI;
	}

	//------------------------------------------------------------------------//

	private IPGeoLocationResult? RequestInCache(string ip)
	{
		IPGeoLocationResult? geoIpJson = null;
		var key = $"{CHACHE_KEY}{ip}";

		if (_cache!.TryGetValue(key, out string? outData))
			geoIpJson = JsonSerializer.Deserialize<IPGeoLocationResult>(outData!);
		return geoIpJson ?? null;
	}

	private void AddCache(IIPGeolocationResult geoIpJson, string ip)
	{
		var key = $"{CHACHE_KEY}{ip}";
		string jsonObj = JsonSerializer.Serialize(geoIpJson);

		if (_cache!.TryGetValue(key, out string? outData))
		{
			if (outData != null)
				return;
		}

		// add to cache
		_cache!.Set(key, jsonObj, _timeExpiration);
	}

	private static bool ConfirmDataRequest(IIPGeolocationResult? geoResult)
	{
		if (geoResult == null || string.IsNullOrEmpty(geoResult!.State) || string.IsNullOrEmpty(geoResult.Country))
			return false;

		return true;
	}

	private static async Task<string?> CallAPI(string apiUrl)
	{
		using var client = new HttpClient();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		client.Timeout = new TimeSpan(0, 0, TIMEOUT_SEC);
		try
		{
			var request = await client.GetAsync($"{apiUrl}");

			if (request.IsSuccessStatusCode)
				return await request.Content.ReadAsStringAsync();
			else
				return null;
		}
		catch { return null; }
	}
}
