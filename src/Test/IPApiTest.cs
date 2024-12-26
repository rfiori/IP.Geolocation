using IP.Geolocation;

namespace Test;

[TestClass]
public sealed class IPApiTest
{
    [TestMethod]
    [DataRow("179.162.174.33")]
    public void Teste_IPApi(string ip)
    {
        var g = FindIP.GetIPGeolocationAsync(ip).Result;

        Assert.IsTrue(g != null && !string.IsNullOrEmpty(g.City));
    }
}
