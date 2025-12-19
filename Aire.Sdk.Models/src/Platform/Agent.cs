// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Aire.Sdk.Models.Platform;

public class AgentToolConfig : Dictionary<string, dynamic>
{
    private T Get<T>(string key, T defaultValue)
    {
        if (TryGetValue(key, out dynamic? value))
        {
            if (value is T ret && ret != null)
            {
                return ret;
            }
        }
        return defaultValue;
    }

    [JsonIgnore]
    [OpenApiProperty(Description = "Tool enabled")]
    public bool Enabled
    {
        get => Get("enabled", false);
        set => this["enabled"] = value;
    }
}

public class AgentConfig
{
    [JsonProperty("name")]
    [OpenApiProperty(Description = "Agent name")]
    public string? Name { get; set; }

    [JsonProperty("labels")]
    [OpenApiProperty(Description = "Localized name labels")]
    public Dictionary<string, string>? Labels { get; set; }

    [JsonProperty("description")]
    [OpenApiProperty(Description = "Description of the agent's purpose")]
    public string? Description { get; set; }

    [JsonProperty("prompt")]
    [OpenApiProperty(Description = "Prompt for the language model.")]
    public string? Prompt { get; set; }

    [JsonProperty("memories")]
    [OpenApiProperty(Description = "List of memory modules identifiers. Default first. Empty if not using memory.")]
    public List<string> Memories { get; set; } = [];

    [JsonProperty("tools")]
    [OpenApiProperty(Description = "Tool configurations by tool name")]
    public Dictionary<string, Dictionary<string, dynamic>>? Tools { get; set; }
}
