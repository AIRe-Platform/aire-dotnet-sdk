// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Resources;

public class DocumentQueryResponse
{
    [JsonProperty("documents", Required = Required.Always)]
    public List<string>? Documents { get; set; }
}
