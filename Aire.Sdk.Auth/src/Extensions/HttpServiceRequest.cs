// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Platform;
using Microsoft.AspNetCore.Http;

namespace Aire.Sdk.Auth.Extensions;

public static class HttpServiceRequestExtensions
{
    public static bool IsServiceRequest(this HttpRequest req)
    {
        var key = AireEnvironment.PlatformServiceKey;
        if (string.IsNullOrWhiteSpace(key))
            throw new ApplicationException("Missing or invalid environment value AIRE_SERVICE_KEY");

        if (!req.Headers.TryGetValue(AirePlaformConstants.AireServiceKeyHeader, out var headerValue))
            return false;

        var value = (string?)headerValue;
        if (string.IsNullOrWhiteSpace(headerValue))
            return false;

        return value == key;
    }

    public static string? GetServiceRequestPlatform(this HttpRequest req)
    {
        if (!req.Headers.TryGetValue(AirePlaformConstants.AireServicePlatformHeader, out var headerValue))
            return null;

        return (string?)headerValue;
    }

    public static string? GetTargetService(this HttpRequest req)
    {
        if (!req.Headers.TryGetValue(AirePlaformConstants.AireServiceTargetHeader, out var headerValue))
            return null;

        return (string?)headerValue;
    }
}
