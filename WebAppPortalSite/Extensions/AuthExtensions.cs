using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using WebAppPortalApiService.Extensions;
using WebAppPortalSite.Common.Options;
namespace WebAppPortalSite.Extensions
{
    public static class AuthExtensions
    {
        public static WebApplicationBuilder AddAuthExtensions(this WebApplicationBuilder builder)
        {
            //I'm showing a simple way of setting up cookie auth in mvc core projects. using what a different server will validate against 
            builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                var apiJwtTokenOptions = builder.Configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>() ?? new();

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "AuthToken";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(apiJwtTokenOptions.ExpirationMinutes - 5);
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthorization();
            return builder;
        }

        public static TokenValidationParameters GetTokenValidationParameters(this JwtTokenOptions jwtOptions) => new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.SecretKey))

        };

        /// <summary>
        /// Here I'm illustrating how we can validate a jwt token
        /// </summary>
        /// <param name="jwtOptions"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ClaimsPrincipal ValidateToken(this JwtTokenOptions jwtOptions, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            return tokenHandler.ValidateToken(token, jwtOptions.GetTokenValidationParameters(), out validatedToken);
        }
    }
}
