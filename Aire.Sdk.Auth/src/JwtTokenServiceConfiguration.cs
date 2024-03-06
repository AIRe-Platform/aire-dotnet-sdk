namespace Aire.Sdk.Auth
{
    public class JwtTokenServiceConfiguration
    {
        public string? SigningKey { get; set; }
        public string? EncryptionKey { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; } 
    }
}
