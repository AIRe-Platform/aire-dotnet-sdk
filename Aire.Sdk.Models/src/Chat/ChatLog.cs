// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Chat;

public class ChatLog
{
    [JsonProperty("messages")]
    public List<ChatMessage>? Messages { get; set; }

    [JsonProperty("state")]
    public object? State { get; set; }

    [JsonProperty("stats")]
    public object? Stats { get; set; }
}
