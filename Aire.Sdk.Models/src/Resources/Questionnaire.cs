using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources
{
    public class Questionnaire
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; } = Guid.NewGuid();

        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("lang", Required = Required.Always)]
        public string? Lang { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("keywords", Required = Required.Always)]
        public string[]? Keywords { get; set; }

        [JsonProperty("content", Required = Required.Always)]
        public List<QuestionnaireContent>? Content { get; set; }

        public Questionnaire() { }
    }
}
