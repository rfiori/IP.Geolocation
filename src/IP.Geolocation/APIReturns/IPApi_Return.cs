using IP.Geolocation.Interfaces;
using IP.Geolocation.Results;

namespace IP.Geolocation.APIReturns;

internal class IPApi_Return
{
#pragma warning disable IDE1006 // Naming Styles

	public string? status { get; set; }
	public DateTime? LastQuery { get; set; }
	public string? country { get; set; }
	public string? countryCode { get; set; }
	public string? regionName { get; set; }
	public string? city { get; set; }
	public string? zip { get; set; }
	public string? lat { get; set; }
	public string? lon { get; set; }
	public string? timezone { get; set; }
	public string? isp { get; set; }
	public string? org { get; set; }
	public bool? mobile { get; set; }

#pragma warning restore IDE1006 // Naming Styles

	public IIPGeolocationResult Result()
	{
		return new IPApi_Result(this);
	}
}
