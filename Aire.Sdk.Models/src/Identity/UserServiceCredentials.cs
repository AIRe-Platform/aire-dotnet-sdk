using Newtonsoft.Json;

namespace Aire.Sdk.Models.Identity
{
    public class UserServiceCredentials
    {
        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("token", Required = Required.Always)]
        public string? Token { get; set; }
    }
}
