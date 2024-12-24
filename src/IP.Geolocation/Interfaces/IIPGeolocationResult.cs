namespace IP.Geolocation.Interfaces;

public interface IIPGeolocationResult
{
	string Status { get; }

	DateTime? LastQuery { get; }

	string Country { get; }

	string CountryCode { get; }

	string State { get; }

	string City { get; }

	string Zip { get; }

	string Latitude { get; }

	string Longitude { get; }

	string Timezone { get; }

	string ISP { get; }

	string Org { get; }

	bool? Mobile { get; }

	string Others { get; }
}
