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

    [JsonProperty("public")]
    public bool? Public { get; set; }

    [JsonProperty("require_consent")]
    public bool? RequireConsent { get; set; }

    [JsonProperty("secret")]
    public string? Secret { get; set; }

    [JsonProperty("grant_types")]
    public List<string>? GrantTypes { get; set; }
}
