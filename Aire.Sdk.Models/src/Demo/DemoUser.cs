// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Demo;

public class DemoUser
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("group")]
    public string? GroupId { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("access_code")]
    public string? AccessCode { get; set; }
}
