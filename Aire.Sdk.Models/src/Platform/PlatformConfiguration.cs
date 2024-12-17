// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Platform;

public class PlatformConfiguration
{
    [JsonProperty("platform", Required = Required.Always)]
    [OpenApiProperty(Description = "Platform details")]
    public Platform? Platform { get; set; }

    [JsonProperty("services", Required = Required.Always)]
    [OpenApiProperty(Description = "Available third-party services on the platform")]
    public List<Service>? Services { get; set; }
}
