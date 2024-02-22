using Aire.Sdk.Models.Platform;

namespace Aire.Sdk.Platform;

public interface IAirePlatformService
{
    /// <summary>
    /// Request platform configuration. Returns internal configuration if service key is configured.
    /// </summary>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetPlatformConfiguration();

    /// <summary>
    /// Request public platform configuration
    /// </summary>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetPublicPlatformConfiguration();

    /// <summary>
    /// Request internal platform configuration
    /// </summary>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetInternalPlatformConfiguration();

    /// <summary>
    /// Platform service key if configured
    /// </summary>
    public abstract string? ServiceKey { get; }
}
