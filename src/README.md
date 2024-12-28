# IPGeolocationMemoryCache

IPGeolocationMemoryCache is a lightweight and efficient library designed to resolve the geolocation of an IP address using free API services. It solves the challenge of repeated API calls for high-traffic applications by caching the resolved geolocation data in memory for 10 minutes (configurable). 

By utilizing this library, you can reduce API request overhead and improve the performance of your application when dealing with frequent IP geolocation lookups. It is ideal for scenarios where geolocation data is critical but maintaining low latency is equally important.

---

## Key Features

- **Free API Services Integration**: Supports free IP geolocation APIs to fetch location data.
- **Memory Cache**: Geolocation results are cached in memory, minimizing redundant API calls.
- **Configurable Cache Duration**: Default cache duration is 10 minutes, but it can be easily adjusted to suit your application's needs.
- **Optimized for High-Traffic**: Designed for applications with high query volumes, ensuring faster response times.
- **Simple Setup**: Easy to integrate into existing .NET applications.

---

## Use Cases

- **Web Applications**: Enhance user experiences by delivering location-based services.
- **Traffic Analytics**: Collect and analyze geographical data for visitor IPs efficiently.
- **Fraud Detection**: Quickly identify suspicious login attempts or transactions based on geolocation.
- **Content Localization**: Serve region-specific content with minimal latency.

---

## How It Works

1. When a request is made to resolve an IP address:
   - The library first checks the in-memory cache for existing geolocation data.
   - If no cached data is found, a request is sent to the configured free geolocation API.
   - The response is stored in memory for the specified cache duration (default: 10 minutes).
2. Subsequent requests for the same IP within the cache duration return the cached data, avoiding unnecessary API calls.

---

## Why Choose IPGeolocationMemoryCache?

- **Performance Optimization**: Significantly reduces latency for geolocation queries by leveraging memory caching.
- **Cost-Effective**: Takes advantage of free geolocation APIs to eliminate additional costs.
- **Scalability**: Handles high volumes of requests seamlessly, making it suitable for demanding applications.
- **Customizable**: Easily adjust caching duration and configure API preferences to fit your needs.

---

Start using IPGeolocationMemoryCache today to enhance your application's geolocation capabilities while maintaining efficiency and performance!
