// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

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
    
    [JsonProperty("is_feedback")]    
    public bool IsFeedback { get; set; }

    public Questionnaire() { }
}

public class QuestionnaireContent
{
    [JsonProperty("id", Required = Required.Always)]
    public string? Id { get; set; }

    [JsonProperty("name", Required = Required.Always)]
    public string? Name { get; set; }

    [JsonProperty("keywords")]
    public string[]? Keywords { get; set; }

    [JsonProperty("questions", Required = Required.Always)]
    public List<QuestionItem>? Questions { get; set; }
}

/// <summary>
/// Embedding metadata for questionnaire
/// </summary>
public class QuestionnaireMetadata
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("relevance")]
    public float? Relevance { get; set; }
}
