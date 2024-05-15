using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class KeywordStats : Dictionary<string, dynamic>
{
}

public class Keyword
{
    [JsonProperty("value", Required = Required.Always)]
    public string? Value { get; set; }

    [JsonProperty("stats", Required = Required.Always)]
    public KeywordStats? Stats { get; set; }
}
