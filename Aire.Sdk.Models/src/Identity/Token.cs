using Newtonsoft.Json;

namespace Aire.Sdk.Models.Identity;

public class AireToken
{
    [JsonProperty("access_token", Required = Required.Always)]
    public string? AccessToken { get; set; }

    [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
    public string? RefreshToken { get; set; } = null;

    [JsonProperty("expires_in", Required = Required.Always)]
    public int ExpiresIn { get; set; }

    [JsonProperty("token_type", Required = Required.Always)]
    public string? TokenType { get; set; }

    [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
    public string? Scope { get; set; } = null;
}
