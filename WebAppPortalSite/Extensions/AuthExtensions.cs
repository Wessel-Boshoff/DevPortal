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

        public static JwtSecurityToken ReadJWTToken(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
             return tokenHandler.ReadJwtToken(token);
        }
    }
}
