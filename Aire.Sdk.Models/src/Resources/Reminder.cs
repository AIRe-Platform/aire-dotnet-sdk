// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class Reminder
{
    [JsonProperty("id")]
    public Guid? Id { get; set; }

    [JsonProperty("trigger_timestamp")]
    public long? TriggerTimestamp { get; set; }

    [JsonProperty("read_timestamp")]
    public long? ReadTimestamp { get; set; }

    [JsonProperty("chat_id")]
    public string? ChatId { get; set; }

    [JsonProperty("content")]
    public ReminderContent? Content { get; set; }
}

public class ReminderContent
{
    [JsonProperty("message", Required = Required.Always)]
    public string Message { get; set; } = string.Empty;
}
