// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.



using Aire.Sdk.Models.Resources;
using Newtonsoft.Json;

namespace Aire.Sdk.Platform.Clients.Models;

public class EmbeddingResponse
{
    [JsonProperty("ids")]
    public List<string>? Ids { get; set; }
}

public class QuestionnaireQueryResponse
{
    [JsonProperty("results", Required = Required.Always)]
    public List<QuestionnaireMetadata>? Results { get; set; }
}

public class ContentQueryResponse
{
    [JsonProperty("results", Required = Required.Always)]
    public List<ContentMetadata>? Results { get; set; }
}
