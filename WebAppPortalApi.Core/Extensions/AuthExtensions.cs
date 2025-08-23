using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Common.Options;

namespace WebAppPortalApi.Core.Extensions
{
    public static class AuthExtensions
    {
        public static WebApplicationBuilder AddAuthExtensions(this WebApplicationBuilder builder)
        {


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var apiJwtTokenOptions = builder.Configuration
                    .GetSection(nameof(JwtTokenOptions))
                    .Get<JwtTokenOptions>() ?? new();

                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = apiJwtTokenOptions.Issuer,
                    ValidAudience = apiJwtTokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiJwtTokenOptions.SecretKey))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireRole(Role.Root.ToString(), Role.Admin.ToString()));
            });


            return builder;
        }

        public static WebApplication UseAuthExtensions(this WebApplication app)
        {

            return app;
        }
    }
}
