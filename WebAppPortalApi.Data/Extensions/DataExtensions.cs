using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalApi.Data.Stores.EventLogs;
using WebAppPortalApi.Data.Stores.Products;
using WebAppPortalApi.Data.Stores.RequestLogs;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Data.Extensions
{
    public static class DataExtensions
    {
        public static WebApplicationBuilder AddDataExtensions(this WebApplicationBuilder builder)
        {

            builder.Services.AddScoped<IUserStore, UserStore>();
            builder.Services.AddScoped<IProductStore, ProductStore>();

            builder.Services.AddScoped<IRequestLogStore, RequestLogStore>();
            builder.Services.AddScoped<IEventLogStore, EventLogStore>();


            return builder;
        }
    }
}
