using IP.Geolocation;

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
        var geoIP = FindIP.GetIPGeolocationAsync(ip).Result;

        Assert.IsTrue(geoIP != null && coutry == geoIP.CountryCode && state == geoIP.State);
    }
}
