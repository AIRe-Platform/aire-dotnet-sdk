
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Aire.Sdk.Auth
{
    public class JwtAuthFeature
    {
        public ClaimsPrincipal Principal { get; set; }
        public JwtSecurityToken Token { get; set; }
        public string UserId { get; set; }
        public string UserKey { get; set; }
        public string JwtEncodedToken { get; set; }
        public bool VerifiedAccount { get; set; }

        public JwtAuthFeature(ClaimsPrincipal principal, JwtSecurityToken token, string userId, string userKey, string jwt, bool verified)
        {
            Principal = principal;
            Token = token;
            UserId = userId;
            UserKey = userKey;
            JwtEncodedToken = jwt;
            VerifiedAccount = verified;
        }
    }
}
