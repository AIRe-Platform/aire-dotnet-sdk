// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


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
    private const string ConfigListCacheKey = "AirePlatformConfigListCacheKey";
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

    public async Task<Dictionary<string, PlatformConfiguration>> GetPlatformConfigurations()
    {
        if (!_cache.TryGetValue(ConfigListCacheKey, out Dictionary<string, PlatformConfiguration>? configs))
        {
            var response = await _httpClient.GetAsync($"v1/configs");
            if (response.IsSuccessStatusCode)
            {
                configs = await response.ReadJsonResponse<Dictionary<string, PlatformConfiguration>>();

                if (configs != null)
                    _cache.Set(ConfigListCacheKey, configs, CacheExpiration);
            }
        }

        if (configs == null)
        {
            _log.LogCritical("Failed to request list of platform configurations");
            throw new AirePlatformException("Unable to list platform configurations");
        }

        return configs;
    }

    public async Task<PlatformConfiguration> GetPlatformConfiguration(string id)
    {
        if (string.IsNullOrEmpty(_options.ServiceKey))
            return await GetPublicPlatformConfiguration(id);
        else
            return await GetInternalPlatformConfiguration(id);
    }

    public async Task<PlatformConfiguration> GetInternalPlatformConfiguration(string id)
    {
        if (string.IsNullOrEmpty(_options.ServiceKey))
        {
            _log.LogCritical("ServiceKey is not configured");
            throw new AirePlatformException("ServiceKey is required but missing");
        }

        string cacheKey = $"{InternalConfigCacheKey}_{id}";
        if (!_cache.TryGetValue(cacheKey, out PlatformConfiguration? config))
        {
            var response = await _httpClient.GetAsync($"v1/config/{id}/internal");
            if (response.IsSuccessStatusCode)
            {
                config = await response.ReadJsonResponse<PlatformConfiguration>();

                if (config != null)
                    _cache.Set(cacheKey, config, CacheExpiration);
            }
        }

        if (config == null)
        {
            _log.LogCritical("Failed to request internal platform configuration");
            throw new AirePlatformException("Unable to determine platform configuration");
        }

        return config;
    }

    public async Task<PlatformConfiguration> GetPublicPlatformConfiguration(string id)
    {
        string cacheKey = $"{PublicConfigCacheKey}_{id}";
        if (!_cache.TryGetValue(cacheKey, out PlatformConfiguration? config))
        {
            var response = await _httpClient.GetAsync($"v1/config/{id}/public");
            if (response.IsSuccessStatusCode)
            {
                config = await response.ReadJsonResponse<PlatformConfiguration>();

                if (config != null)
                    _cache.Set(cacheKey, config, CacheExpiration);
            }
        }

        if (config == null)
        {
            _log.LogCritical("Failed to request public platform configuration");
            throw new AirePlatformException("Unable to determine platform configuration");
        }

        return config;
    }

    public async Task<Module?> GetServiceModule(string platformId, ModuleType moduleType, string serviceId)
    {
        var platform = await GetPlatformConfiguration(platformId);

        var svc = platform.Services?.Where(x => x.Name == serviceId).FirstOrDefault();
        if (svc == null)
        {
            _log?.LogError($"No service with name '{serviceId}' found");
            return null;
        }

        var module = svc.Modules?.Where(x => x.Type == moduleType).FirstOrDefault();
        if (module == null)
        {
            _log?.LogError($"The service '{serviceId}' does not have an AI module");
            return null;
        }

        return module;
    }

    public async Task<List<Module>> GetAvailableModulesOfType(string platformId, ModuleType moduleType)
    {
        var modules = new List<Module>();
        var platform = await GetPlatformConfiguration(platformId);

        if (platform.Platform?.Modules?.ContainsKey(moduleType) ?? false)
        {
            var defaultModules = platform.Platform.Modules[moduleType]
                .Where(x => x.Type == moduleType)
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

    public async Task<Module?> GetDefaultModuleOfType(string platformId, ModuleType moduleType)
    {
        var platform = await GetPlatformConfiguration(platformId);
        var modules = platform.Platform?.Modules?.FirstOrDefault(x => x.Key == moduleType);
        return modules?.Value.FirstOrDefault();
    }
}
