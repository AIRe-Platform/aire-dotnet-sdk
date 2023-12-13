
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aire.Sdk.Auth.Models
{
    public class JwtAuthFeature
    {
        public ClaimsPrincipal Principal { get; set; }
        public JwtSecurityToken Token { get; set; }

        public Guid User { get; set; }

        public string UserKey { get; set; }

        public JwtAuthFeature(ClaimsPrincipal principal, JwtSecurityToken token, Guid user, string userKey)
        {
            Principal = principal;
            Token = token;
            User = user;
            UserKey = userKey;
        }
    }
}
