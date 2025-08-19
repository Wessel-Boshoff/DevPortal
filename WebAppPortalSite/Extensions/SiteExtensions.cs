using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using WebAppPortalApiService.Extensions;
using WebAppPortalSite.Common.Options;
namespace WebAppPortalSite.Extensions
{
    public static class SiteExtensions
    {
        public static WebApplicationBuilder AddSiteExtensions(this WebApplicationBuilder builder)
        {
            //Options
            builder.Services.Configure<ApiServiceOptions>(builder.Configuration.GetSection(nameof(ApiServiceOptions)));
            builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection(nameof(JwtTokenOptions)));

            builder.AddAuthExtensions();
            builder.AddServiceExtensions();
            builder.Services.AddLogging();
            //Handlers
            //   builder.Services.AddScoped<IRequestLoggerHandler, RequestLoggerHandler>();

            return builder;
        }

 
        public static WebApplication UseSiteExtensions(this WebApplication app)
        {

            return app;
        }
    }
}
