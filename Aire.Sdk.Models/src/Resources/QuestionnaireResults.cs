using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class QuestionnaireResults
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("questionnaire_id", Required = Required.Always)]
    public string? QuestionnaireId { get; set; }

    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonProperty("preliminary")]
    public Dictionary<string, dynamic>? Preliminary { get; set; }

    [JsonProperty("answers", Required = Required.Always)]
    public List<QuestionnaireAnswer>? Answers { get; set; }

    [JsonProperty("summary", Required = Required.Always)]
    public string? Summary { get; set; }

    [JsonProperty("prompts")]
    public List<string>? Prompts { get; set;}
}
