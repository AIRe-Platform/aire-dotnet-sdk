// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Audit;

public class AuditEventData : Dictionary<string, dynamic?>
{
    public bool TryGetValue<T>(string key, out T? value)
    {
        value = default;
        if (base.TryGetValue(key, out dynamic? val))
        {
            if (val is T)
            {
                value = val;
                return true;
            }
        }
        return false;
    }

    public AuditEventData() { }
    public AuditEventData(Dictionary<string, dynamic?> data) : base(data) { }

    [JsonProperty("source", Required = Required.Always)]
    public string? Source
    {
        get => TryGetValue("source", out string? value) ? value : null;
        set => this["source"] = value;
    }

    [JsonProperty("user_id")]
    public string? UserId
    {
        get => TryGetValue("user_id", out string? value) ? value : null;
        set => this["user_id"] = value;
    }

    [JsonProperty("operation")]
    public string? Operation
    {
        get => TryGetValue("operation", out string? value) ? value : null;
        set => this["operation"] = value;
    }
}

public class AuditEvent : AuditEventData
{
    [JsonProperty("resource", Required = Required.Always)]
    public string? Resource
    {
        get => TryGetValue("resource", out string? value) ? value : null;
        set => this["resource"] = value;
    }

    [JsonProperty("event_id", Required = Required.Always)]
    public Guid? EventId
    {
        get => TryGetValue("event_id", out Guid? value) ? value : null;
        set => this["event_id"] = value;
    }

    [JsonProperty("timestamp", Required = Required.Always)]
    public DateTime? Timestamp
    {
        get => TryGetValue("timestamp", out DateTime? value) ? value : null;
        set => this["timestamp"] = value;
    }
}
