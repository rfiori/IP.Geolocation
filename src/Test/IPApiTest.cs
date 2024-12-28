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
		IMemoryCache? _cache = null; // new MemoryCache(new MemoryCacheOptions());
		var fIP = new FindIP(_cache!);

		var geoIP = fIP.GetIPGeolocationAsync(ip).Result;

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
		var fIP = new FindIP(_cache);

		var ips = new List<string> { "179.162.174.33", "35.208.27.10", "18.217.72.66", "35.208.27.10", "179.162.174.33" };

		//var geoIP = fIP.GetIPGeolocationAsync(ip).Result;
		var lstResult = new List<IIPGeolocationResult?>();

		foreach (var item in ips)
		{
			lstResult.Add(fIP.GetIPGeolocationAsync(item).Result);
			Task.Delay(3000);
		}

		Assert.IsTrue(
			lstResult[0]?.Country == lstResult[4]?.Country &&
			lstResult[1]?.City == lstResult[3]?.City
			);
	}
}
