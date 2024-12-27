using IP.Geolocation;
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
        var _cache = null; // new MemoryCache(new MemoryCacheOptions());
        var fIP = new FindIP(_cache);

        var geoIP = fIP.GetIPGeolocationAsync(ip).Result;

        Assert.IsTrue(
            geoIP != null &&
            geoIP.CountryCode!.Contains(coutry) &&
            (geoIP.State!.Contains(state, StringComparison.OrdinalIgnoreCase) || state.Contains(geoIP.State, StringComparison.OrdinalIgnoreCase))
            );
    }

    [TestMethod]
    [DataRow(, "BR", "Minas Gerais")]
    [DataRow(, "US", "Iowa")]
    [DataRow("18.217.72.66", "US", "Ohio")]
    [DataRow("20.184.5.215", "SG", "Central Singapore")]
    public void Teste_IPApi_With_Cache(string ip, string coutry, string state)
    {
        var _cache = new MemoryCache(new MemoryCacheOptions());
        var fIP = new FindIP(_cache);

        var ips = new List<string> { "179.162.174.33", "35.208.27.10", "35.208.27.10", "179.162.174.33" };

        var geoIP = fIP.GetIPGeolocationAsync(ip).Result;

        foreach

        Assert.IsTrue(
            geoIP != null &&
            geoIP.CountryCode!.Contains(coutry) &&
            (geoIP.State!.Contains(state, StringComparison.OrdinalIgnoreCase) || state.Contains(geoIP.State, StringComparison.OrdinalIgnoreCase))
            );
    }
}
