using Newtonsoft.Json;

namespace Aire.Sdk.AI.Models
{
    public class EmbeddingResponse
    {
        [JsonProperty("ids")]
        public List<string>? Ids { get; set; }
    }
}
