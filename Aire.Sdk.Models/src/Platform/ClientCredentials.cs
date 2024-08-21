// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Platform
{
    public class ClientCredentials
    {
        [JsonProperty("client_id", Required = Required.Always)]
        [OpenApiProperty(Description = "Client identifier")]
        public string? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.AllowNull)]
        [OpenApiProperty(Description = "Client secret")]
        public string? ClientSecret { get; set; }
    }
}
