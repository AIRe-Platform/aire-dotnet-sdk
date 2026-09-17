// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.IdentityModel.Tokens.Jwt;

namespace Aire.Sdk.Auth;

public interface IJwtTokenService
{
    JwtSecurityToken? ValidateToken(string token);
    bool CheckAuthorization(JwtAuthFeature? auth, string? requiredScopes = null);
    bool CheckAuthorization(JwtAuthFeature? auth, IReadOnlyList<string>? requiredScopes = null);
    string IssueNewToken(string subject, string role, List<string> scopes, Dictionary<string, object> claims, TimeSpan lifetime);
}
