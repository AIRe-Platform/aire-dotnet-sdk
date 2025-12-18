// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aire.Sdk.Platform.Clients;

public class AireClientFactory(
    IHttpClientFactory httpClientFactory,
    ILoggerFactory loggerFactory,
    IOptions<AirePlatformServiceConfiguration> options) : IAireClientFactory
{
    public async Task<IAireAiClient> CreateAiClient(Module module, string? accessToken, bool asService)
    {
        string? serviceKey = asService ? options.Value.ServiceKey : null;
        return new AireAiClient(
            httpClientFactory.CreateClient(), module, accessToken, serviceKey,
            loggerFactory.CreateLogger<AireAiClient>());
    }

    public async Task<IAireMemoryClient> CreateMemoryClient(Module module, string? accessToken, bool asService)
    {
        string? serviceKey = asService ? options.Value.ServiceKey : null;
        return new AireMemoryClient(
            httpClientFactory.CreateClient(), module, accessToken, serviceKey,
            loggerFactory.CreateLogger<AireMemoryClient>());
    }
}
