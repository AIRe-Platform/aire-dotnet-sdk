using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aire.Sdk.Models.Resources;

[JsonConverter(typeof(StringEnumConverter))]
public enum ContentType
{
    [EnumMember(Value = "url")]
    URL,

    [EnumMember(Value = "image")]
    Image,

    [EnumMember(Value = "video")]
    Video,

    [EnumMember(Value = "document")]
    Document,
}

public static class ContentTypeExtensions
{
    public static bool IsBlobType(this ContentType type)
    {
        return type switch
        {
            ContentType.Image or ContentType.Video or ContentType.Document => true,
            _ => false,
        };
    }
}

public class Content
{
    [JsonProperty("id")]
    public Guid? Id { get; set; } = Guid.NewGuid();

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("hidden")]
    public bool? Hidden { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("type")]
    public ContentType? Type { get; set; }

    [JsonProperty("views_count")]
    public int? ViewsCount { get; set; }

    [JsonProperty("viewers_rating")]
    public int? ViewersRating { get; set; }

    [JsonProperty("modified")]
    public DateTime Modified { get; set; }

    [JsonProperty("keywords")]
    public string[]? Keywords { get; set; }
}
