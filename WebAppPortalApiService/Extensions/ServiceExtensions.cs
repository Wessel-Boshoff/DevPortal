using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Options;

namespace WebAppPortalApiService.Extensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddServiceExtensions(this WebApplicationBuilder builder)
        {
            //Setup
            builder.Services.AddHttpClient<ApiService>();

            //Services
            builder.Services.AddScoped<IUserService, UserService>();

            return builder;
        }
    }
}
