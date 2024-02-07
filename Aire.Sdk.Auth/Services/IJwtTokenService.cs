using System.IdentityModel.Tokens.Jwt;
using Aire.Sdk.Auth.Models;
using Aire.Sdk.Auth.Roles;
using Aire.Sdk.Auth.Scopes;

namespace Aire.Sdk.Auth.Services
{
    public interface IJwtTokenService
    {
        JwtSecurityToken? ValidateToken(string token);
        bool CheckAuthorization(JwtAuthFeature? auth, string? allowedRoles = null, string? requiredScopes = null);
        bool CheckAuthorization(JwtAuthFeature? auth, AireRoles? allowedRoles = null, AireScopes? requiredScopes = null);
        string IssueNewToken(string subject, string role, List<string> scopes, Dictionary<string, object> claims, TimeSpan lifetime);
    }
}
