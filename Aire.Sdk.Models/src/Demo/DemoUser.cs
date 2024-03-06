using Newtonsoft.Json;

namespace Aire.Sdk.Models.Demo;

public class DemoUser
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("group")]
    public string? GroupId { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("access_code")]
    public string? AccessCode { get; set; }
}
