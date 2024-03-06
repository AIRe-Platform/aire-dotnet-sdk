using System.IdentityModel.Tokens.Jwt;

namespace Aire.Sdk.Auth.Services
{
    public interface IJwtTokenService
    {
        JwtSecurityToken? ValidateToken(string token);
        bool CheckAuthorization(JwtAuthFeature? auth, string? requiredScopes = null);
        bool CheckAuthorization(JwtAuthFeature? auth, AireScopes? requiredScopes = null);
        string IssueNewToken(string subject, string role, List<string> scopes, Dictionary<string, object> claims, TimeSpan lifetime);
    }
}
