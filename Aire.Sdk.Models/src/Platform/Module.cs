// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Runtime.Serialization;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Aire.Sdk.Models.Platform;

[JsonConverter(typeof(StringEnumConverter))]
public enum ModuleType
{
    [EnumMember(Value = "id")]
    ID,

    [EnumMember(Value = "ai")]
    AI,

    [EnumMember(Value = "memory")]
    Memory
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ModuleAccess
{
    // Public modules are read-only
    // These can be public databases containing generic data
    [EnumMember(Value = "public")]
    Public,

    // Public modules that require service-to-service authentication
    // These cannot be accessed by public clients
    [EnumMember(Value = "service")]
    Service,

    // Private modules require that users connect with third-party ID providers
    // These modules can be used to store user data
    [EnumMember(Value = "private")]
    Private
}

public class Module
{
    [JsonProperty("id")]
    [OpenApiProperty(Description = "Module identifier")]
    public string? Id { get; set; }

    [JsonProperty("type", Required = Required.Always)]
    [OpenApiProperty(Description = "Type of the module")]
    public ModuleType Type { get; set; }

    [JsonProperty("endpoint", Required = Required.Always)]
    [OpenApiProperty(Description = "Module endpoint root")]
    public string? Endpoint { get; set; }

    [JsonProperty("access", Required = Required.Always)]
    [OpenApiProperty(Description = """
        Required access level.
        Public modules do not generally require authentication.
        Service modules can only be accessed from other modules with server-to-server authentication.
        Private modules require the user to be logger in.
        """)]
    public ModuleAccess Access { get; set; }

    [JsonProperty("credentials", NullValueHandling = NullValueHandling.Ignore)]
    [OpenApiProperty(Description = "Server-to-server client credentials")]
    public ClientCredentials? Credentials { get; set; }

    [JsonProperty("settings", NullValueHandling = NullValueHandling.Ignore)]
    [OpenApiProperty(Description = "Module settings, internal")]
    public Dictionary<string, dynamic>? Settings { get; set; }
}

public static class ModuleSettings
{
    public const string Memory_VectorDbName = "vector_database_name";
    public const string AI_PersonalityPrompt = "personality_prompt";
}
