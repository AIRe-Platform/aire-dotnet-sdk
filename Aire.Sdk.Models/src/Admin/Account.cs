using Newtonsoft.Json;

namespace Aire.Sdk.Models.Admin;

public class Account
{
    [JsonProperty("id", Required = Required.Always)]
    public string? Id { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("verified")]
    public bool? Verified { get; set;  }

    [JsonProperty("last_login")]
    public DateTime? LastLogin { get; set; }

    [JsonProperty("eula_accepted")]
    public DateTime? EulaAccepted { get; set; }

    [JsonProperty("role")]
    public string? Role { get; set; }

    [JsonProperty("override_scopes")]
    public bool OverrideScopes { get; set; }

    [JsonProperty("scopes")]
    public List<string>? Scopes { get; set; }

    [JsonProperty("additional_scopes")]
    public List<string>? AdditionalScopes { get; set; }
}
