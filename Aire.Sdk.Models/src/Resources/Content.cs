using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources
{
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
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("views_count")]
        public int? ViewsCount { get; set; }
        [JsonProperty("viewers_rating")]
        public int? ViewersRating { get; set; }
        [JsonProperty("injured_type")]
        public string? InjuredType { get; set; }
        [JsonProperty("age")]
        public DateTime Modified { get; set; }
        [JsonProperty("keywords")]
        public string[]? Keywords { get; set; }
        


        public Content() { }
    }
}
