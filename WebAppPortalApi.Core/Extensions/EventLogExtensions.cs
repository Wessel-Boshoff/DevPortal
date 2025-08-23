using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAppPortalApi.Core.Providers;
using WebAppPortalApi.Data.Stores.EventLogs;

namespace WebAppPortalApi.Core.Extensions
{
    public static class EventLogExtensions
    {
        internal static WebApplicationBuilder AddEventLogExtensions(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            var collection = builder.Services;
            var eventLoggerStoreService = collection.BuildServiceProvider().GetService<IEventLogStore>();
            builder.Logging.AddProvider(new EventLoggerProvider(eventLoggerStoreService));


            return builder;
        }

        internal static WebApplication UseEventLogExtensions(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });

            return app;
        }
    }
}
