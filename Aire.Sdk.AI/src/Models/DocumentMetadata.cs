using Newtonsoft.Json;

namespace Aire.Sdk.AI.Models;

public class DocumentMetadata
{
    [JsonProperty("source")]
    public string? Source { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("relevance")]
    public float? Relevance { get; set; }
}
