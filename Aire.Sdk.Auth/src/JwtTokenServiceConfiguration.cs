// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


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
