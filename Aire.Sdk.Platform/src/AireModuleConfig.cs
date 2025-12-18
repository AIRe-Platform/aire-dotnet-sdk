// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Platform;

namespace Aire.Sdk.Platform;

public class AireModuleConfig
{
    public ModuleType? Type { get; set; }
    public string? Identifier { get; set; }
}
