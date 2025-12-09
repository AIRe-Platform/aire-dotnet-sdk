// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Platform;

namespace Aire.Sdk.Platform;

public interface IAirePlatformService
{
    /// <summary>
    /// Request a list of platform configuration.
    /// </summary>
    /// <returns>Platform configuration list</returns>
    public abstract Task<Dictionary<string, PlatformConfiguration>> GetPlatformConfigurations();
    
    /// <summary>
    /// Request platform configuration. Returns internal configuration if service key is configured.
    /// </summary>
    /// <param name="platformId">Platform identifier</param>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetPlatformConfiguration(string platformId);

    /// <summary>
    /// Request public platform configuration
    /// </summary>
    /// <param name="platformId">Platform identifier</param>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetPublicPlatformConfiguration(string platformId);

    /// <summary>
    /// Request internal platform configuration
    /// </summary>
    /// <param name="platformId">Platform identifier</param>
    /// <returns>Platform configuration object</returns>
    public abstract Task<PlatformConfiguration> GetInternalPlatformConfiguration(string platformId);

    /// <summary>
    /// Retrieve platform module
    /// </summary>
    /// <param name="platformId">Platform identifier</param>
    /// <param name="moduleType">Module type</param>
    /// <param name="moduleId">Optional module ID (if null, return first/default)</param>
    /// <returns>Module object if found, otherwise false</returns>
    public abstract Task<Module?> GetPlatformModule(string platformId, ModuleType moduleType, string? moduleId);

    /// <summary>
    /// Retrieve external service module
    /// </summary>
    /// <param name="platformId">Platform identifier</param>
    /// <param name="moduleType">Module type</param>
    /// <param name="serviceId">Module identifier</param>
    /// <param name="moduleId">Optional module ID (if null, return first/default)</param>
    /// <returns>Module object if found, otherwise null</returns>
    public abstract Task<Module?> GetExternalServiceModule(string platformId, ModuleType moduleType, string serviceId, string? moduleId);
}
