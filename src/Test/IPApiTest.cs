using IPGeolocationMemoryCache;
using IPGeolocationMemoryCache.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Test;

[TestClass]
public sealed class IPApiTest
{
	[TestMethod]
	[DataRow("179.162.174.33", "BR", "Minas Gerais")]
	[DataRow("35.208.27.10", "US", "Iowa")]
	[DataRow("18.217.72.66", "US", "Ohio")]
	[DataRow("20.184.5.215", "SG", "Central Singapore")]
	public void Teste_IPApi(string ip, string coutry, string state)
	{
		var ipGeo = new IpGeoLocation(null);

		var geoIP = ipGeo.GetIPGeolocationAsync(ip).Result;

		Assert.IsTrue(
			geoIP != null &&
			geoIP.CountryCode!.Contains(coutry) &&
			(geoIP.State!.Contains(state, StringComparison.OrdinalIgnoreCase) || state.Contains(geoIP.State, StringComparison.OrdinalIgnoreCase))
		);
	}

	[TestMethod]
	public void Teste_IPApi_With_Cache()
	{
		var _cache = new MemoryCache(new MemoryCacheOptions());
		var ipGeo = new IpGeoLocation(_cache);

		var lstIp = new List<string> { "179.162.174.33", "35.208.27.10", "18.217.72.66", "35.208.27.10", "179.162.174.33" };

		var lstResult = new List<IIPGeolocationResult?>();

		foreach (var item in lstIp)
		{
			lstResult.Add(ipGeo.GetIPGeolocationAsync(item).Result);
			Task.Delay(3000);
		}
        
		Console.WriteLine($"1th coutry = {lstResult[0]?.Country} | 5th coutry = {lstResult[4]?.Country}");
        Console.WriteLine($"2th coutry = {lstResult[2]?.Country} | 4th coutry = {lstResult[3]?.Country}");

        Assert.IsTrue(
			lstResult[0]?.Country == lstResult[4]?.Country &&
			lstResult[1]?.City == lstResult[3]?.City
		);
	}
}
