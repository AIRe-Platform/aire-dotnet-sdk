using Aire.Sdk.AspNetCore;
using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aire.Sdk.Platform;

public class AirePlatformService : IAirePlatformService
{
    private readonly HttpClient _httpClient;
    private readonly AirePlatformServiceConfiguration _options;
    private readonly IMemoryCache _cache;
    private readonly ILogger<AirePlatformService> _log;

    private const string PublicConfigCacheKey = "AirePlatformPublicConfigCacheKey";
    private const string InternalConfigCacheKey = "AirePlatformInternalConfigCacheKey";
    private readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(60);

    public AirePlatformService(
        HttpClient httpClient,
        IOptions<AirePlatformServiceConfiguration> options,
        IMemoryCache cache,
        ILogger<AirePlatformService> log)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _cache = cache;
        _log = log;

        if (string.IsNullOrEmpty(_options.ServiceUrl))
            throw new AirePlatformException("ServiceUrl is not configured");

        _httpClient.BaseAddress = new Uri(_options.ServiceUrl);

        if (!string.IsNullOrEmpty(_options.ServiceKey))
            _httpClient.DefaultRequestHeaders.Add(AirePlaformConstants.AireServiceKeyHeader, _options.ServiceKey);
    }

    public string? ServiceKey { get => _options.ServiceKey; }

    public async Task<PlatformConfiguration> GetPlatformConfiguration()
    {
        if (string.IsNullOrEmpty(ServiceKey))
            return await GetPublicPlatformConfiguration();
        else
            return await GetInternalPlatformConfiguration();
    }

    public async Task<PlatformConfiguration> GetInternalPlatformConfiguration()
    {
        if (string.IsNullOrEmpty(_options.ServiceKey))
            throw new AirePlatformException("ServiceKey is required but missing");

        if (!_cache.TryGetValue(InternalConfigCacheKey, out PlatformConfiguration? config))
        {
            var response = await _httpClient.GetAsync("v1/config/internal");
            if (response.IsSuccessStatusCode)
            {
                config = await response.ReadJsonResponse<PlatformConfiguration>();

                if (config != null)
                    _cache.Set(InternalConfigCacheKey, config, CacheExpiration);
            }
        }

        if (config == null)
            throw new AirePlatformException("Unable to determine platform configuration");

        return config;
    }

    public async Task<PlatformConfiguration> GetPublicPlatformConfiguration()
    {
        if (!_cache.TryGetValue(PublicConfigCacheKey, out PlatformConfiguration? config))
        {
            var response = await _httpClient.GetAsync("v1/config");
            if (response.IsSuccessStatusCode)
            {
                config = await response.ReadJsonResponse<PlatformConfiguration>();
                
                if (config != null)
                    _cache.Set(PublicConfigCacheKey, config, CacheExpiration);
            }
        }

        if (config == null)
            throw new AirePlatformException("Unable to determine platform configuration");

        return config;
    }
}
