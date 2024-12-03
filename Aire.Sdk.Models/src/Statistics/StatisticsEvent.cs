// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Newtonsoft.Json;

namespace Aire.Sdk.Models.Statistics;

public class StatisticsEvent : Dictionary<string, dynamic?>
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

    [JsonProperty("id")]
    public Guid? Id
    {
        get => TryGetValue("id", out Guid? value) ? value : null;
        set => this["id"] = value;
    }

    [JsonProperty("event_name", Required = Required.Always)]
    public string? EventName
    {
        get => TryGetValue("event_name", out string? value) ? value : null;
        set => this["event_name"] = value;
    }

    [JsonProperty("ts", Required = Required.Always)]
    public DateTime? Timestamp
    {
        get => TryGetValue("ts", out DateTime? value) ? value : null;
        set => this["ts"] = value;
    }

    [JsonProperty("client_id")]
    public string? ClientId
    {
        get => TryGetValue("client_id", out string? value) ? value : null;
        set => this["client_id"] = value;
    }

    [JsonProperty("client_ver")]
    public string? ClientVersion
    {
        get => TryGetValue("client_ver", out string? value) ? value : null;
        set => this["client_ver"] = value;
    }
}
