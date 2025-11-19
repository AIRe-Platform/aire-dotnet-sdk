
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aire.Sdk.Auth;

public class JwtAuthFeature(
    ClaimsPrincipal principal, JwtSecurityToken token,
    string userId, string userKey, string jwt, bool verified, string? platform)
{
    public ClaimsPrincipal Principal { get; set; } = principal;
    public JwtSecurityToken Token { get; set; } = token;
    public string UserId { get; set; } = userId;
    public string UserKey { get; set; } = userKey;
    public string JwtEncodedToken { get; set; } = jwt;
    public bool VerifiedAccount { get; set; } = verified;
    public string? Platform { get; set; } = platform;
}

