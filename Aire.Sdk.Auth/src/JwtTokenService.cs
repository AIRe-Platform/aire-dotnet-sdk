// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Aire.Sdk.Auth;

public class JwtTokenService : IJwtTokenService
{
    private readonly ILogger<JwtTokenService> _log;
    private readonly JwtSecurityTokenHandler _handler;
    private readonly TokenValidationParameters _validationParams;

    private readonly JwtTokenServiceConfiguration _config;

    public JwtTokenService(
        JwtSecurityTokenHandler handler,
        TokenValidationParameters validationParams,
        JwtTokenServiceConfiguration config,
        ILogger<JwtTokenService> log)
    {
        _handler = handler;
        _validationParams = validationParams;
        _config = config;
        _log = log;
    }


    public bool CheckAuthorization(JwtAuthFeature? auth, string? requiredScopes = null)
    {
        AireScopes? scopes = (requiredScopes == null) ? null : AireScopes.ParseString(requiredScopes);
        return CheckAuthorization(auth, scopes);
    }

    public bool CheckAuthorization(JwtAuthFeature? auth, IReadOnlyList<string>? requiredScopes)
    {
        if (auth == null) return false;

        if (requiredScopes != null)
        {
            var grantedScopes = auth.Principal.Claims.FirstOrDefault(x => x.Type == "scope");
            if (grantedScopes == null)
                return false;
            var scopeValues = AireScopes.ParseString(grantedScopes.Value);
            foreach (var scope in requiredScopes)
            {
                if (!scopeValues.Contains(scope))
                {
                    _log.LogWarning($"Missing scope '{scope}'");
                    return false;
                }
            }
        }

        return true;
    }

    public string IssueNewToken(string subject, string role, List<string> scopes, Dictionary<string, object> claims, TimeSpan lifetime)
    {
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                    new("sub", subject),
                    new(ClaimTypes.Role, role)
                ]),
            Expires = DateTime.UtcNow + lifetime,
            IssuedAt = DateTime.UtcNow,
            Issuer = _config.Issuer,
            Audience = _config.Audience,
            Claims = claims
        };

        if (_config.SigningKey != null)
        {
            var signingKeyBytes = Encoding.ASCII.GetBytes(_config.SigningKey);
            var signingKey = new SymmetricSecurityKey(signingKeyBytes);
            descriptor.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
        }

        if (_config.EncryptionKey != null)
        {
            var encKeyBytes = Encoding.ASCII.GetBytes(_config.EncryptionKey);
            var encKey = new SymmetricSecurityKey(encKeyBytes);
            descriptor.EncryptingCredentials = new EncryptingCredentials(encKey, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes256CbcHmacSha512);
        }

        if (scopes != null)
            descriptor.Claims.Add("scope", string.Join(" ", scopes));

        var token = _handler.CreateJwtSecurityToken(descriptor);
        return _handler.WriteToken(token);
    }

    public JwtSecurityToken? ValidateToken(string token)
    {
        try
        {
            _handler.ValidateToken(token, _validationParams, out SecurityToken securityToken);
            return (JwtSecurityToken)securityToken;
        }
        catch
        {
            return null;
        }
    }
}

