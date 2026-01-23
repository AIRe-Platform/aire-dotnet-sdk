// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Newtonsoft.Json;

namespace Aire.Sdk.Models.Invites;

public class InviteToken
{
    [JsonProperty("token")]
    public string? Token { get; set; }

    [JsonProperty("email_hash")]
    public string? EmailHash { get; set; }

    [JsonProperty("expiry")]
    public DateTime Expiry { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    [JsonProperty("client_id")]
    public string? ClientId { get; set; }

    [JsonProperty("chat_id")]
    public string? ChatId { get; set; }

    [JsonProperty("platform")]
    public string? Platform { get; set; }

    [JsonProperty("account_upgrade")]
    public bool AccountUpgrade { get; set; }
}
