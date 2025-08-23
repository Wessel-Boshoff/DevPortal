using System.Reflection;
using WebAppPortalSite.Data.Stores.Users;
using WebAppPortalSite.Data.Stores.RequestLogs;
using WebAppPortalSite.Data.Stores.EventLogs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalSite.Data.Stores.Products;

namespace WebAppPortalSite.Data.Extensions
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
