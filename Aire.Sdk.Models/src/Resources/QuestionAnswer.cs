// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class QuestionAnswer
{
    [JsonProperty("questionnaire_id")]
    public string? QuestionnaireId { get; set; }

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