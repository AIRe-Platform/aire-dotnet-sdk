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
        {
            _log.LogCritical("ServiceUrl is not configured");
            throw new AirePlatformException("ServiceUrl is not configured");
        }

        _httpClient.BaseAddress = new Uri(_options.ServiceUrl);

        if (!string.IsNullOrEmpty(_options.ServiceKey))
            _httpClient.DefaultRequestHeaders.Add(AirePlaformConstants.AireServiceKeyHeader, _options.ServiceKey);
    }

    public async Task<PlatformConfiguration> GetPlatformConfiguration()
    {
        if (string.IsNullOrEmpty(_options.ServiceKey))
            return await GetPublicPlatformConfiguration();
        else
            return await GetInternalPlatformConfiguration();
    }

    public async Task<PlatformConfiguration> GetInternalPlatformConfiguration()
    {
        if (string.IsNullOrEmpty(_options.ServiceKey))
        {
            _log.LogCritical("ServiceKey is not configured");
            throw new AirePlatformException("ServiceKey is required but missing");
        }

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
        {
            _log.LogCritical("Failed to request internal platform configuration");
            throw new AirePlatformException("Unable to determine platform configuration");
        }

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
        {
            _log.LogCritical("Failed to request publid platform configuration");
            throw new AirePlatformException("Unable to determine platform configuration");
        }

        return config;
    }

    public async Task<Module?> GetServiceModule(ModuleType moduleType, string serviceNameOrId)
    {
        var platform = await GetPlatformConfiguration();

        var svc = platform.Services?.Where(x => x.Name == serviceNameOrId).FirstOrDefault();
        if (svc == null)
        {
            _log?.LogError($"No service with name '{serviceNameOrId}' found");
            return null;
        }

        var module = svc.Modules?.Where(x => x.Type == moduleType).FirstOrDefault();
        if (module == null)
        {
            _log?.LogError($"The service '{serviceNameOrId}' does not have an AI module");
            return null;
        }

        return module;
    }

    public async Task<List<Module>> GetAvailableModulesOfType(ModuleType moduleType)
    {
        var modules = new List<Module>();
        var platform = await GetPlatformConfiguration();

        if(platform.Platform?.Modules != null)
        {
            var defaultModules = platform.Platform.Modules
                .Where(x => x.Value.Type == moduleType)
                .Select(x => x.Value)
                .ToList();
            modules.AddRange(defaultModules);
        }

        if (platform.Services != null)
        {
            var serviceModules = platform.Services
                .Where(x => x.Modules != null)
                .Select(x => x.Modules!.Where(y => y.Type == moduleType))
                .SelectMany(x => x);
            modules.AddRange(serviceModules);
        }

        return modules;
    }

    public async Task<Module?> GetDefaultModuleOfType(ModuleType moduleType)
    {
        var platform = await GetPlatformConfiguration();
        return platform.Platform?.Modules?
            .Where(x => x.Value.Type == moduleType)
            .Select(x => x.Value)
            .FirstOrDefault();
    }
}
