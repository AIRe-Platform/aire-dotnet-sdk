using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class DocumentQueryResponse
{
    [JsonProperty("documents", Required = Required.Always)]
    public List<string>? Documents { get; set; }
}
