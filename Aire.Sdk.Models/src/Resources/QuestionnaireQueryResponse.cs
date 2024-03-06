using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class QuestionnaireQueryResponse
{
    [JsonProperty("results", Required = Required.Always)]
    public List<DocumentMetadata>? Results { get; set; }
}
