// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Invites;

public class InviteCode
{
    [JsonProperty("code", Required = Required.Always)]
    public Guid? Code { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    [JsonProperty("client_id")]
    public string? ClientId { get; set; }

    [JsonProperty("expiry")]
    public DateTime Expiry { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("invite_lifespan")]
    public long InviteLifeSpan { get; set; }

    [JsonProperty("link")]
    public string? Link { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; }

    [JsonProperty("used")]
    public int Used { get; set; }

    [JsonProperty("account_upgrade")]
    public bool AccountUpgrade { get; set; }

    [JsonProperty("platform")]
    public string? Platform { get; set; }
}
