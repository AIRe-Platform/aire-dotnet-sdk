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
    /// Try finding a named module of certain type
    /// </summary>
    /// <param name="moduleType">Module type</param>
    /// <param name="serviceNameOrId">Module name or identifier</param>
    /// <returns>Module object if found, otherwise null</returns>
    public abstract Task<Module?> GetServiceModule(ModuleType moduleType, string serviceNameOrId);

    /// <summary>
    /// List available modules of certain type
    /// </summary>
    /// <param name="moduleType">Module type</param>
    /// <returns>List of modules</returns>
    public abstract Task<List<Module>> GetAvailableModulesOfType(ModuleType moduleType);

    /// <summary>
    /// Returns platform's default module of certain type.
    /// </summary>
    /// <param name="moduleType">Module type</param>
    /// <returns>Module object if configured, otherwise null</returns>
    public abstract Task<Module?> GetDefaultModuleOfType(ModuleType moduleType);
}
