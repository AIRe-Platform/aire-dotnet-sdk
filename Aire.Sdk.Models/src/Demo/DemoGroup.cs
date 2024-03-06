using Newtonsoft.Json;

namespace Aire.Sdk.Models.Demo;

public class DemoGroup
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
}
