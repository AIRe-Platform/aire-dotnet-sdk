// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using Aire.Sdk.Models.Resources;

namespace Aire.Sdk.Models.Chat
{
    public class ChatMessage
    {
        [JsonProperty("type")]
        [OpenApiProperty(Description = "Indicates the type of the message")]
        public string? Type { get; set; }

        [JsonProperty("role", Required = Required.Always)]
        [OpenApiProperty(Description = "The role of the message's author")]
        public ChatRole? Role { get; set; }

        [JsonProperty("timestamp")]
        [OpenApiProperty(Description = "The message timestamp in Unix time")]
        public long Timestamp { get; set; }

        [JsonProperty("content")]
        [OpenApiProperty(Description = "Message content")]
        public string? Content { get; set; }

        [JsonProperty("rating")]
        [OpenApiProperty(Description = "Message rating")]
        public int? Rating { get; set; }

        [JsonProperty("question")]
        [OpenApiProperty(Description = "Questionnaire question and answer")]
        public QuestionAnswer? Question { get; set; }

        [JsonProperty("hidden")]
        [OpenApiProperty(Description = "Hides message from the chat")]
        public bool Hidden { get; set; } = false;

        [JsonProperty("media")]
        [OpenApiProperty(Description = "List of media content identifiers")]
        public List<string>? Media { get; set; }

        [JsonProperty("reminder")]
        [OpenApiProperty(Description = "Reminder associated with the message")]
        public Reminder? Reminder { get; set; }

        [JsonProperty("theme")]
        [OpenApiProperty(Description = "Message theme")]
        public string? Theme { get; set; }

        [JsonProperty("agent")]
        [OpenApiProperty(Description = "Assistant name")]
        public string? Agent { get; set; }

        [JsonProperty("localize")]
        [OpenApiProperty(Description = "The content is a localization key which should be used for showing a localized message")]
        public bool? Localize { get; set; }
    }
}
