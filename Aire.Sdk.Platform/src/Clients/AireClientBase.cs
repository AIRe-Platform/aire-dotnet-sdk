
using System.Net.Http.Headers;
using Aire.Sdk.Models.Platform;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform.Clients;

public class AireClientBase
{
    protected readonly HttpClient _httpClient;

    public AireClientBase(HttpClient httpclient, Module serviceModule, string? accessToken)
    {
        _httpClient = httpclient;
        ConfigureModuleClient(serviceModule, accessToken);
    }

    private void ConfigureModuleClient(Module serviceModule, string? accessToken)
    {
        if (string.IsNullOrEmpty(serviceModule.Endpoint))
            throw new AirePlatformException("Service module endpoint is null or empty");

        // Check that the endpoint ends with slash, otherwise HttpClient.BaseAddress will not work correctly with paths.
        string endpoint = serviceModule.Endpoint;
        if (endpoint[^1] != '/')
            endpoint += "/";

        _httpClient.BaseAddress = new Uri(endpoint);
        _httpClient.DefaultRequestHeaders.Clear();

        if (serviceModule.Access == ModuleAccess.Service)
        {
            // Set service credentials if configured
            if (serviceModule.Credentials != null)
            {
                var credentials = serviceModule.Credentials;

                if (!string.IsNullOrEmpty(credentials.ClientId))
                    _httpClient.DefaultRequestHeaders.Add(AirePlaformConstants.AireClientIdHeader, credentials.ClientId);

                if (!string.IsNullOrEmpty(credentials.ClientSecret))
                    _httpClient.DefaultRequestHeaders.Add(AirePlaformConstants.AireClientSecretHeader, credentials.ClientSecret);
            }
        }
        else // public or private
        {
            // Set access token if present
            if (accessToken != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            else if (serviceModule.Access == ModuleAccess.Private)
                throw new AirePlatformException("This module requires an access token");
        }
    }

    protected static async Task LogIfErrorResponse(HttpResponseMessage response, ILogger log)
    {
        if (response.IsSuccessStatusCode)
            return;

        log.LogError($"Request failed: {response.StatusCode}");
        if (response.Content != null)
        {
            var body = await response.Content.ReadAsStringAsync();
            log.LogError($"Error response: {body}");
        }
    }
}