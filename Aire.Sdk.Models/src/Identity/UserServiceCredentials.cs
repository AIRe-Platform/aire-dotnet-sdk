using Newtonsoft.Json;

namespace Aire.Sdk.Models.Identity;

public class UserServiceCredentials
{
    [JsonProperty("service_name", Required = Required.Always)]
    public string? ServiceName { get; set; }

    [JsonProperty("token", Required = Required.Always)]
    public AireToken? Token { get; set; }
}
