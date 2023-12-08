
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aire.Sdk.Auth.Models
{
    public class JwtAuthFeature
    {
        public ClaimsPrincipal Principal { get; set; }
        public JwtSecurityToken Token { get; set; }

        public JwtAuthFeature(ClaimsPrincipal principal, JwtSecurityToken token)
        {
            Principal = principal;
            Token = token;
        }
    }
}
