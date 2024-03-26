using Newtonsoft.Json;

namespace Aire.Sdk.Models.Admin;

public class Client
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("active")]
    public bool? Active { get; set; }

    [JsonProperty("redirect_uri")]
    public string? RedirectUri { get; set; }

    [JsonProperty("scopes")]
    public List<string>? Scopes { get; set; }
}
