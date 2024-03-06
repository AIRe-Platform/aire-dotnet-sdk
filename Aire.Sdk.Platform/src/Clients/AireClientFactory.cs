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

    public async Task<IAireAiClient?> CreateAiClient(string? accessToken = null, string? serviceName = null)
    {
        var module = await FindModule(ModuleType.AI, serviceName);
        if(module == null)
            return null;

        return new AireAiClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireAiClient>());
    }

    public async Task<IAireMemoryClient?> CreateMemoryClient(string? accessToken = null, string? serviceName = null)
    {        
        var module = await FindModule(ModuleType.Memory, serviceName);
        if(module == null)
            return null;

        return new AireMemoryClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireMemoryClient>());
        throw new NotImplementedException();
    }

    private async Task<Module?> FindModule(ModuleType type, string? serviceName)
    {
        Module? module = null;
        if(serviceName != null)
            module = await _platform.GetServiceModule(type, serviceName);
        else
            module = await _platform.GetDefaultModuleOfType(type);

        if(module == null)
            _log.LogCritical($"Failed to find {type} module '{serviceName ?? "default"}'");

        return module;
    }
}
