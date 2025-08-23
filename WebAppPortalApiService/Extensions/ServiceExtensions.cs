using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalApiService.Services.Dashboards;
using WebAppPortalApiService.Services.Products;
using WebAppPortalApiService.Services.Users;

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
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();

            return builder;
        }
    }
}
