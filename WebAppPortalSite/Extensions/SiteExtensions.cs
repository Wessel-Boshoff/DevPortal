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
            builder.Services.AddSession(options =>
            {
                var apiJwtTokenOptions = builder.Configuration
                    .GetSection(nameof(JwtTokenOptions))
                    .Get<JwtTokenOptions>() ?? new();

                options.IdleTimeout = TimeSpan.FromMinutes(apiJwtTokenOptions.ExpirationMinutes - 5);
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });


            return builder;
        }


        public static WebApplication UseSiteExtensions(this WebApplication app)
        {

            return app;
        }
    }
}
