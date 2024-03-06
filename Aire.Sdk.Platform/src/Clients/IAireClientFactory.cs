namespace Aire.Sdk.Platform.Clients;

public interface IAireClientFactory
{
    public Task<IAireAiClient?> CreateAiClient(string? accessToken = null, string? serviceName = null);
    public Task<IAireMemoryClient?> CreateMemoryClient(string? accessToken = null, string? serviceName = null);
}
