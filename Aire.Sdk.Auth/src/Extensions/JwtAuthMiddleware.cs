// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Aire.Sdk.Auth.Extensions
{
    public static class JwtAuthExtension
    {
        public static IFunctionsWorkerApplicationBuilder UseJwtAuth(
            this IFunctionsWorkerApplicationBuilder builder,
            JwtTokenServiceConfiguration config)
        {
            var signingKeyBytes = Encoding.ASCII.GetBytes(config.SigningKey!);
            var decryptionKeyBytes = Encoding.ASCII.GetBytes(config.EncryptionKey!);

            var validationParams = new TokenValidationParameters
            {
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes),
                TokenDecryptionKey = new SymmetricSecurityKey(decryptionKeyBytes),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false
            };

            if (!string.IsNullOrEmpty(config.Issuer))
            {
                validationParams.ValidateIssuer = true;
                validationParams.ValidIssuers = config.Issuer.Split(
                    ",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                );
            }

            if (!string.IsNullOrEmpty(config.Audience))
            {
                validationParams.RequireAudience = true;
                validationParams.ValidateAudience = true;
                validationParams.ValidAudiences = config.Audience.Split(
                    ",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                );
            }

            builder.Services
                .AddSingleton<JwtSecurityTokenHandler>()
                .AddSingleton<IJwtTokenService, JwtTokenService>()
                .AddSingleton(config)
                .AddSingleton(validationParams);

            builder.UseMiddleware<JwtAuthMiddleware>();

            return builder;
        }
    }

    public class JwtAuthMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly JwtSecurityTokenHandler _handler;
        private readonly TokenValidationParameters _validationParams;
        private readonly ILogger<JwtAuthMiddleware> _log;

        public JwtAuthMiddleware(JwtSecurityTokenHandler handler, TokenValidationParameters validationParameters, ILogger<JwtAuthMiddleware> log)
        {
            _handler = handler;
            _validationParams = validationParameters;
            _log = log;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var httpContext = context.GetHttpContext();
            var tokenString = ParseAuthHeader(httpContext);
            if (!string.IsNullOrWhiteSpace(tokenString))
            {
                try
                {
                    ClaimsPrincipal principal = _handler.ValidateToken(tokenString, _validationParams, out var jwt);
                    var token = (JwtSecurityToken)jwt;

                    var key = token.Claims.FirstOrDefault(x => x.Type == AireClaims.UserEncryptionKey)?.Value;
                    if (string.IsNullOrWhiteSpace(key))
                        throw new InvalidCredentialException("Missing or invalid claim: " + AireClaims.UserEncryptionKey);

                    bool verified = token.Claims.FirstOrDefault(x => x.Type == AireClaims.VerifiedAccount)?.Value == "1";
                    context.Features.Set(new JwtAuthFeature(principal, token, token.Subject, key!, tokenString, verified));
                }
                catch (Exception ex)
                {
                    _log.LogWarning(ex, "Token validation failed");
                }
            }

            await next(context);
        }

        private string? ParseAuthHeader(HttpContext? http)
        {
            if (http == null) return null;
            if (http.Request == null) return null;

            IHeaderDictionary headers = http.Request.Headers;
            if (!headers.TryGetValue("Authorization", out var value))
            {
                _log.LogWarning("Missing Authorization header");
                return null;
            }

            var parts = ((string?)value)?.Split(" ");
            if (parts == null)
            {
                _log.LogWarning("Missing Authorization value");
                return null;
            }

            if (parts[0] != "Bearer")
            {
                _log.LogWarning("Invalid Authorization scheme");
                return null;
            }

            if (parts.Length != 2)
            {
                _log.LogWarning("Invalid Authorization header format");
                return null;
            }

            return parts[1];
        }
    }
}