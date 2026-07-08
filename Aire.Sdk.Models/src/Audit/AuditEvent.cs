// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Audit;

public class AuditEvent(IDictionary<string, dynamic?> data)
{
    public bool TryGetValue<T>(string key, out T? value)
    {
        value = default;
        if (data.TryGetValue(key, out dynamic? val))
        {
            if (val is T)
            {
                value = val;
                return true;
            }
        }
        return false;
    }

    public Dictionary<string, dynamic?> ToDictionary()
    {
        return new Dictionary<string, dynamic?>(data);
    }

    [JsonProperty("resource", Required = Required.Always)]
    public string? Resource
    {
        get => TryGetValue("resource", out string? value) ? value : null;
        set => data["resource"] = value;
    }

    [JsonProperty("event_id", Required = Required.Always)]
    public Guid? EventId
    {
        get => TryGetValue("event_id", out Guid? value) ? value : null;
        set => data["event_id"] = value;
    }

    [JsonProperty("timestamp", Required = Required.Always)]
    public DateTime? Timestamp
    {
        get => TryGetValue("timestamp", out DateTime? value) ? value : null;
        set => data["timestamp"] = value;
    }

    [JsonProperty("source", Required = Required.Always)]
    public string? Source
    {
        get => TryGetValue("source", out string? value) ? value : null;
        set => data["source"] = value;
    }

    [JsonProperty("user_id")]
    public string? UserId
    {
        get => TryGetValue("user_id", out string? value) ? value : null;
        set => data["user_id"] = value;
    }

    [JsonProperty("operation")]
    public string? Operation
    {
        get => TryGetValue("operation", out string? value) ? value : null;
        set => data["operation"] = value;
    }
}
