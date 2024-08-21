// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Chat
{
    public class ChatLogMetadata
    {
        [JsonProperty("id", Required = Required.Always)]
        [OpenApiProperty(Description = "The chat log identifier")]
        public string? Id { get; set; }

        [JsonProperty("time", Required = Required.Always)]
        [OpenApiProperty(Description = "The timestamp when the chat log was last modified")]
        public DateTimeOffset? Time { get; set; }
    }
}
