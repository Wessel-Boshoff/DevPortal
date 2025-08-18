using System.Reflection;
using WebAppPortalApiService.Extensions;
namespace WebAppPortalSite.Extensions
{
    public static class SiteExtensions
    {
        public static WebApplicationBuilder AddSiteExtensions(this WebApplicationBuilder builder)
        {

            builder.AddServiceExtensions();
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
