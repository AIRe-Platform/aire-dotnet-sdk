
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Chat;

public class ChatLog
{
    [JsonProperty("messages")]
    public List<ChatMessage>? Messages { get; set; }

    [JsonProperty("state")]
    public object? State { get; set; }
}
