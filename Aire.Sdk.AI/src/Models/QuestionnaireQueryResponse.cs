using Newtonsoft.Json;

namespace Aire.Sdk.AI.Models
{
    public class QuestionnaireQueryResponse
    {
        [JsonProperty("results", Required = Required.Always)]
        public List<string>? Results { get; set; }
    }
}
