using Microsoft.AspNetCore.Http;

namespace Aire.Sdk.Auth.Extensions;

public static class HttpServiceRequestExtensions
{
    public static bool IsServiceRequest(this HttpRequest req)
    {
        var key = Environment.GetEnvironmentVariable("AIRE_SERVICE_KEY");

        if (string.IsNullOrWhiteSpace(key))
            throw new ApplicationException("Missing or invalid environment value AIRE_SERVICE_KEY");

        if (!req.Headers.TryGetValue("Aire-Service-Key", out var headerValue))
            return false;

        var value = (string?)headerValue;
        if (string.IsNullOrWhiteSpace(headerValue))
            return false;

        return value == key;
    }
}
