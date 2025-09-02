// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class Translation
{
    [JsonProperty("value")]
    public string? Value { get; set; }

    [JsonProperty("languageID")]
    public string? LanguageID { get; set; }
}

public class Keyword
{
    [JsonProperty("value", Required = Required.Always)]
    public string? Value { get; set; }

    [JsonProperty("stats", Required = Required.Always)]
    public Dictionary<string, dynamic>? Stats { get; set; }

    [JsonProperty("translations")]
    public List<Translation>? Translations { get; set; }

    [JsonProperty("prompt")]
    public string? Prompt { get; set; }

    [JsonProperty("documents")]
    public List<string>? Documents { get; set; }
}
