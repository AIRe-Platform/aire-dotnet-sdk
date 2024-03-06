using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class EmbeddingResponse
{
    [JsonProperty("ids")]
    public List<string>? Ids { get; set; }
}
