using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAppPortalSite.Common.Options;

namespace WebAppPortalApiService.Extensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddServiceExtensions(this WebApplicationBuilder builder)
        {

            builder.Services.Configure<ApiServiceOptions>(builder.Configuration.GetSection(nameof(ApiServiceOptions)));
            builder.Services.AddHttpClient<ApiService>();
            //Handlers
            //   builder.Services.AddScoped<IRequestLoggerHandler, RequestLoggerHandler>();

            return builder;
        }
    }
}
