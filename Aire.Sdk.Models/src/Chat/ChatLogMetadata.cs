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
