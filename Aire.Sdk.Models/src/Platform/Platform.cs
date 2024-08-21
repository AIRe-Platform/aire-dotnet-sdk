// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Platform
{
    public class Platform
    {
        [JsonProperty("name", Required = Required.Always)]
        [OpenApiProperty(Description = "Name of the platform")]
        public string? Name { get; set; }

        [JsonProperty("modules", Required = Required.Always)]
        [OpenApiProperty(Description = "Dictionary of the service's core modules")]
        public Dictionary<ModuleType, Module>? Modules { get; set; }
    }
}
