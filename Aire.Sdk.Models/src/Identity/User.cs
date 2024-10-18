// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aire.Sdk.Models.Identity;

[JsonConverter(typeof(StringEnumConverter))]
public enum UserGender
{
    [EnumMember(Value = "male")]
    Male,

    [EnumMember(Value = "female")]
    Female,

    [EnumMember(Value = "other")]
    Other
}

public class UserPreferences
{
    [JsonProperty("experimental_custom_prompt", NullValueHandling = NullValueHandling.Ignore)]
    public string? CustomPrompt { get; set; }
}

public class UserPrivate
{
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    [JsonProperty("gender")]
    public UserGender? Gender { get; set; }

    [JsonProperty("year_of_birth")]
    public int? YearOfBirth { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }

    [JsonProperty("bio")]
    public string? Bio { get; set; }

    [JsonProperty("connected_services")]
    public List<UserServiceCredentials>? ConnectedServices { get; set; }

    [JsonProperty("preferences")]
    public UserPreferences? Preferences { get; set; }
}

public class User : UserPrivate
{
    [JsonProperty("uuid")]
    public string? UUID { get; set; }

    [JsonProperty("last_login")]
    public DateTime? LastLogin { get; set; }

    [JsonProperty("eula_accepted")]
    public DateTime? EulaAccepted { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }
}
