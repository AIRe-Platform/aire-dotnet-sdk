// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Extensions.Options;

namespace Aire.Sdk.Platform;

public class AireModuleSettingsService(
    IAirePlatformService platformService,
    IOptions<AireModuleConfig> options
) : IAireModuleSettingsService
{
    public async Task<T?> Get<T>(string platform, string key)
    {
        var type = options.Value.Type ??
            throw new AirePlatformException("Module type not configured");

        var id = options.Value.Identifier ??
            throw new AirePlatformException("Module identifier not configured");

        var module = await platformService.GetPlatformModule(platform, type, id);

        if (module?.Settings == null)
            return default;

        if (module.Settings.TryGetValue(key, out dynamic? value))
        {
            if (value is T t)
                return t;
        }
        return default;
    }
}
