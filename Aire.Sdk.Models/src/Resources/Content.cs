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
        public string? URL { get; set; }
        [JsonProperty("views_count")]
        public int? Views_count { get; set; }
        [JsonProperty("viewers_rating")]
        public int? Viewers_rating { get; set; }
        [JsonProperty("injured_type")]
        public string? Injured_type { get; set; }
        [JsonProperty("age")]
        public string? Age { get; set; }
        [JsonProperty("gender")]
        public string? Gender { get; set; }
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }


        public Content() { }
    }
}
