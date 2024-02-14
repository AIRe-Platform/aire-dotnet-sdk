using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class QuestionnaireAnswer
{
    [JsonProperty("question_id", Required = Required.Always)]
    public string? QuestionId { get; set; }

    [JsonProperty("type", Required = Required.Always)]
    public QuestionOptionType? Type { get; set; }

    [JsonProperty("question", Required = Required.Always)]
    public string? Question { get; set; }

    [JsonProperty("prompt")]
    public string? Prompt { get; set; }

    [JsonProperty("answer")]
    public dynamic? Answer { get; set; }

    [JsonProperty("options")]
    public object? Options { get; set; }
}