// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Audit;

public class AuditLog
{
    [JsonProperty("start")]
    public DateTime? Start { get; set; }

    [JsonProperty("end")]
    public DateTime? End { get; set; }

    [JsonProperty("sources")]
    public List<string>? Sources { get; set; }

    [JsonProperty("events")]
    public List<AuditEvent>? Events { get; set; }
}
