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

    public async Task<IAireAiClient> CreateAiClient(Module module, string? accessToken)
    {
        return new AireAiClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireAiClient>());
    }

    public async Task<IAireMemoryClient> CreateMemoryClient(Module module, string? accessToken)
    {        
        return new AireMemoryClient(
            _httpClientFactory.CreateClient(), module, accessToken,
            _loggerFactory.CreateLogger<AireMemoryClient>());
        throw new NotImplementedException();
    }
}
