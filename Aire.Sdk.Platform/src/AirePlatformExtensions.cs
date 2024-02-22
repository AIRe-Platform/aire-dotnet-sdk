using System.Net.Http.Headers;
using Aire.Sdk.Models.Identity;
using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform;

public static class AirePlatformExtensions
{
    public static Module? GetServiceModule<MType>(this PlatformConfiguration platform, ModuleType moduleType, string? serviceNameOrId = null, ILogger? log = null)
    {
        if (serviceNameOrId != null)
        {
            var svc = platform.Services?.Where(x => x.Name == serviceNameOrId).FirstOrDefault();
            if (svc == null)
            {
                log?.LogError($"No service with name '{serviceNameOrId}' found");
                return null;
            }

            var module = svc.Modules?.Where(x => x.Type == moduleType).FirstOrDefault();
            if (module == null)
            {
                log?.LogError($"The service '{serviceNameOrId}' does not have an AI module");
                return null;
            }

            return module;
        }
        else // use platform default
        {
            Module? module = null;
            platform.Platform?.Modules?.TryGetValue(moduleType, out module);

            if (module == null)
            {
                log?.LogError($"The platform does not have an AI module");
                return null;
            }

            return module;
        }
    }

    public static List<Module> GetAvailableModulesOfType(this PlatformConfiguration platform, ModuleType moduleType)
    {
        var modules = new List<Module>();

        var defaultModule = platform.GetDefaultModuleOfType(moduleType);
        if (defaultModule != null)
            modules.Add(defaultModule);

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

    public static Module? GetDefaultModuleOfType(this PlatformConfiguration platform, ModuleType moduleType)
    {
        if (platform.Platform != null)
        {
            if (platform.Platform.Modules != null)
            {
                if (platform.Platform.Modules.TryGetValue(moduleType, out Module? defaultModule))
                    return defaultModule;
            }
        }
        return null;
    }

    public static void ConfigureModuleClient(this HttpClient client, Module serviceModule, UserServiceCredentials? userServiceCredentials = null)
    {
        if (string.IsNullOrEmpty(serviceModule.Endpoint))
            throw new AirePlatformException("Service module endpoint is null or empty");

        // Check that the endpoint ends with slash, otherwise HttpClient.BaseAddress will not work correctly with paths.
        string endpoint = serviceModule.Endpoint;
        if(endpoint[^1] != '/')
            endpoint += "/";

        client.BaseAddress = new Uri(endpoint);
        client.DefaultRequestHeaders.Clear();

        // Set user credentials
        if (userServiceCredentials?.Token != null)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userServiceCredentials.Token);
        }
        else if (serviceModule.Access == ModuleAccess.Private)
        {
            throw new AirePlatformException("This module requires user authentication");
        }

        // Set service client credentials
        if (serviceModule.Access == ModuleAccess.Service)
        {
            if (serviceModule.Credentials != null)
            {
                var credentials = serviceModule.Credentials;

                if (!string.IsNullOrEmpty(credentials.ClientId))
                    client.DefaultRequestHeaders.Add(AirePlaformConstants.AireClientIdHeader, credentials.ClientId);

                if (!string.IsNullOrEmpty(credentials.ClientSecret))
                    client.DefaultRequestHeaders.Add(AirePlaformConstants.AireClientSecretHeader, credentials.ClientSecret);
            }
        }
    }
}
