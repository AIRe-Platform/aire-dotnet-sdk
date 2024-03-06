using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform.Clients;

public class AireMemoryClient : AireClientBase, IAireMemoryClient
{
    private readonly ILogger<AireMemoryClient> _log;

    public AireMemoryClient(HttpClient httpclient, Module serviceModule, string? accessToken, ILogger<AireMemoryClient> log) 
        : base(httpclient, serviceModule, accessToken)
    {
        _log = log;
    }

    public Task<bool> DestroyUserData(bool anonymize)
    {
        _log.LogWarning("Destroying user data is not implemented yet!");
        return Task.Run(() => {
            return true;
        });
    }
}
