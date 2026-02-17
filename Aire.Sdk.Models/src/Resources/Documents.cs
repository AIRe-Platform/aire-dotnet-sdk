// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aire.Sdk.Models.Resources;


[JsonConverter(typeof(StringEnumConverter))]
public enum DocumentStatus
{
    [EnumMember(Value = "unprocessed")]
    Unprocessed,

    [EnumMember(Value = "queued")]
    Queued,

    [EnumMember(Value = "processing")]
    Processing,

    [EnumMember(Value = "processed")]
    Processed,

    [EnumMember(Value = "failure")]
    Failure,
}

public class DocumentMetadata
{
    [JsonProperty("source")]
    public Guid? Source { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("filename")]
    public string? FileName { get; set; }

    [JsonProperty("lang")]
    public string? Language { get; set; }

    [JsonProperty("copyright")]
    public string? Copyright { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("status")]
    public DocumentStatus? Status { get; set; }
}

public class DocumentSearchResult
{
    [JsonProperty("id")]
    public Guid? Id { get; set; }

    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("metadata")]
    public DocumentMetadata? Metadata { get; set; }

    [JsonProperty("relevance")]
    public float? Relevance { get; set; }
}
