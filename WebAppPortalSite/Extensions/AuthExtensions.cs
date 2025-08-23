using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Options;

namespace WebAppPortalSite.Extensions
{
    public static class AuthExtensions
    {
        public static WebApplicationBuilder AddAuthExtensions(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    var apiJwtTokenOptions = builder.Configuration
                        .GetSection(nameof(JwtTokenOptions))
                        .Get<JwtTokenOptions>() ?? new();

                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.Cookie.Name = "AuthToken";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(apiJwtTokenOptions.ExpirationMinutes - 5);
                    options.SlidingExpiration = false;

                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireRole(Role.Root.ToString(), Role.Admin.ToString()));
            });

            return builder;
        }

        public static JwtSecurityToken ReadJWTToken(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(token);
        }
    }
}
