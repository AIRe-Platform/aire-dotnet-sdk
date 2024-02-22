using Newtonsoft.Json;

namespace Aire.Sdk.AI.Models
{
    public class DocumentQueryResponse
    {
        [JsonProperty("documents", Required = Required.Always)]
        public List<string>? Documents { get; set; }
    }
}
