// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Invites;

public class InviteCodeCreateRequest
{
    [JsonProperty("client_id", Required = Required.Always)]
    public string? ClientId { get; set; }

    [JsonProperty("valid_days", Required = Required.Always)]
    public int ValidDays { get; set; }

    [JsonProperty("trial_duration", Required = Required.Always)]
    public int TrialDuration { get; set; }

    [JsonProperty("use_limit", Required = Required.Always)]
    public int UseLimit { get; set; }

    [JsonProperty("allow_account_upgrade", Required = Required.Always)]
    public bool AllowAccountUpgrade { get; set; }
}

public class InviteAccountUpgradeRequest
{
    [JsonProperty("password", Required = Required.Always)]
    public string? Password { get; set; }
}
