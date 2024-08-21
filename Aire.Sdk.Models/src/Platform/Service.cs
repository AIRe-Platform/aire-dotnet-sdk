// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Platform
{
    public class Service
    {
        [JsonProperty("id")]
        [OpenApiProperty(Description = "Service identifier")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        [OpenApiProperty(Description = "Name of the service")]
        public string? Name { get; set; }

        [JsonProperty("owner")]
        [OpenApiProperty(Description = "Resource owner's UUID")]
        public string? Owner { get; set; }

        [JsonProperty("modules")]
        [OpenApiProperty(Description = "List of available service modules")]
        public List<Module>? Modules { get; set; }

        [JsonProperty("active")]
        [OpenApiProperty(Description = "Is the service enabled")]
        public bool? Active { get; set; }
    }
}
