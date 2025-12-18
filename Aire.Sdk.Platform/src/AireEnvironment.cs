// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


namespace Aire.Sdk.Platform;

public static class AireEnvironment
{
    public static string? ModuleIdentifier => Environment.GetEnvironmentVariable("AIRE_MODULE_ID");
    public static string? PlatformServiceKey => Environment.GetEnvironmentVariable("AIRE_SERVICE_KEY");
    public static string? PlatformServiceUrl => Environment.GetEnvironmentVariable("AIRE_SERVICE_BASE");
    public static string? TokenSigningKey => Environment.GetEnvironmentVariable("TOKEN_SIGNING_KEY");
    public static string? TokenEncryptionKey => Environment.GetEnvironmentVariable("TOKEN_ENCRYPTION_KEY");
}
