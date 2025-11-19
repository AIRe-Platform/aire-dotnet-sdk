// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform.Clients;

public class AireClientFactory : IAireClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAirePlatformService _platform;
    private readonly ILogger<AireClientFactory> _log;
    private readonly ILoggerFactory _loggerFactory;

    public AireClientFactory(
        IHttpClientFactory httpClientFactory, 
        IAirePlatformService platform, 
        ILogger<AireClientFactory> log,
        ILoggerFactory loggerFactory)
    {
        _httpClientFactory = httpClientFactory;
        _platform = platform;
        _log = log;
        _loggerFactory = loggerFactory;
    }

    public async Task<IAireAiClient?> CreateAiClient(string platformId, string? accessToken, string? serviceId)
    {
        var module = await FindModule(platformId, ModuleType.AI, serviceId);
        if(module == null)
            return null;

        return new AireAiClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireAiClient>());
    }

    public async Task<IAireMemoryClient?> CreateMemoryClient(string platformId, string? accessToken, string? serviceId)
    {        
        var module = await FindModule(platformId, ModuleType.Memory, serviceId);
        if(module == null)
            return null;

        return new AireMemoryClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireMemoryClient>());
        throw new NotImplementedException();
    }

    private async Task<Module?> FindModule(string platformId, ModuleType type, string? serviceId)
    {
        Module? module;
        if (serviceId != null)
            module = await _platform.GetServiceModule(platformId, type, serviceId);
        else
            module = await _platform.GetDefaultModuleOfType(platformId, type);

        if(module == null)
            _log.LogCritical($"Failed to find {type} module '{serviceId ?? "default"}'");

        return module;
    }
}
