// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Identity;

public class UserServiceCredentials
{
    [JsonProperty("service_name", Required = Required.Always)]
    public string? ServiceName { get; set; }

    [JsonProperty("token", Required = Required.Always)]
    public AireToken? Token { get; set; }
}
