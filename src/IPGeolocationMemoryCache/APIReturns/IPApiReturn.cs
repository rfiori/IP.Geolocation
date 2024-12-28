using IPGeolocationMemoryCache.Interfaces;
using System.Text.Json.Serialization;

namespace IPGeolocationMemoryCache.APIReturns;

/*
 * Exemple api return
 * 
{
	"status":"success",
	"country":"Brazil",
	"countryCode":"BR",
	"region":"MG",
	"regionName":"Minas Gerais",
	"city":"Belo Horizonte",
	"zip":"30000","lat":-19.9221,
	"lon":-43.9347,
	"timezone":"America/Sao_Paulo",
	"isp":"Vivo",
	"org":"TELEF�NICA BRASIL S.A","as":"AS18881 TELEFÔNICA BRASIL S.A",
	"query":"179.162.174.33"
}
 */

internal class IPApiReturn : IIPGeolocationResult
{
	[JsonPropertyName("status")]
	[JsonConverter(typeof(StringOrIntConverter))]
	public string? Status { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }

	[JsonPropertyName("regionName")]
	public string? State { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("zip")]
	public string? Zip { get; set; }

	[JsonPropertyName("lat")]
	public dynamic? Latitude { get; set; }

	[JsonPropertyName("lon")]
	public dynamic? Longitude { get; set; }

	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }

	[JsonPropertyName("isp")]
	public string? ISP { get; set; }

	[JsonPropertyName("org")]
	public string? Org { get; set; }

	[JsonPropertyName("mobile")]
	public bool? Mobile { get; set; }

	public string? Others { get; set; }

	public DateTime? LastQuery { get; } = DateTime.UtcNow;
}
