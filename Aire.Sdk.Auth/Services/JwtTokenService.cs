using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aire.Sdk.Auth.Models;
using Aire.Sdk.Auth.Roles;
using Aire.Sdk.Auth.Scopes;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Aire.Sdk.Auth.Services
{
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


        public bool CheckAuthorization(JwtAuthFeature? auth, string? allowedRoles = null, string? requiredScopes = null)
        {
            var allowed = allowedRoles?.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var required = requiredScopes?.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            AireRoles? roles = (allowed == null) ? null : new AireRoles(allowed);
            AireScopes? scopes = (required == null) ? null : new AireScopes(required);

            return CheckAuthorization(auth, roles, scopes);
        }

        public bool CheckAuthorization(JwtAuthFeature? auth, AireRoles? allowedRoles, AireScopes? requiredScopes)
        {
            if(auth == null) return false;

            if(allowedRoles != null)
            {
                var matchingRole = allowedRoles.FirstOrDefault(x => auth.Principal.IsInRole(x));
                if(matchingRole == null)
                {
                    _log.LogWarning($"User does not have appropriate role to access this resource");
                    return false;
                }
            }

            if(requiredScopes != null)
            {
                var grantedScopes = auth.Principal.Claims.FirstOrDefault(x => x.Type == "scope");
                if(grantedScopes == null)
                    return false;
                var scopeValues = grantedScopes.Value.Split(" ");
                foreach(var scope in requiredScopes)
                {
                    if(!scopeValues.Contains(scope))
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
                Subject = new ClaimsIdentity(new Claim[] {
                    new("sub", subject),
                    new(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow + lifetime,
                IssuedAt = DateTime.UtcNow,
                Issuer = _config.Issuer,
                Audience = _config.Audience,
                Claims = claims
            };

            if(_config.SigningKey != null)
            {
                var signingKeyBytes = Encoding.ASCII.GetBytes(_config.SigningKey);
                var signingKey = new SymmetricSecurityKey(signingKeyBytes);
                descriptor.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
            }

            if(_config.EncryptionKey != null)
            {
                var encKeyBytes = Encoding.ASCII.GetBytes(_config.EncryptionKey);
                var encKey = new SymmetricSecurityKey(encKeyBytes);
                descriptor.EncryptingCredentials = new EncryptingCredentials(encKey, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes256CbcHmacSha512);
            }

            if(scopes != null)
                descriptor.Claims.Add("scope", string.Join(" ", scopes));

            var token = _handler.CreateJwtSecurityToken(descriptor);
            return _handler.WriteToken(token);
        }

        public JwtSecurityToken? ValidateToken(string token)
        {
            try
            {
                _handler.ValidateToken(token, _validationParams, out SecurityToken securityToken);
                return (JwtSecurityToken) securityToken;
            }
            catch
            {
                return null;
            }
        }
    }
}
