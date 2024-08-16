// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


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

    [JsonProperty("answers", Required = Required.Always)]
    public List<QuestionAnswer>? Answers { get; set; }

    [JsonProperty("summary", Required = Required.Always)]
    public string? Summary { get; set; }

    [JsonProperty("prompts")]
    public List<string>? Prompts { get; set;}
}
