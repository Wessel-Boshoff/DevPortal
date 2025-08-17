using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAppPortalApi.Data.Database;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Data.Stores.RequestLogs;
using WebAppPortalApi.Data.Stores.EventLogs;
using WebAppPortalApi.Providers;

namespace WebAppPortalApi.Extensions
{
    public static class EventLogExtensions
    {
        public static WebApplicationBuilder AddEventLogExtensions(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            var collection = builder.Services;
            var eventLoggerStoreService = collection.BuildServiceProvider().GetService<IEventLogStore>();
            builder.Logging.AddProvider(new EventLoggerProvider(eventLoggerStoreService));


            return builder;
        }

        public static WebApplication UseEventLogExtensions(this WebApplication app)
        {
            app.Use(async (context, next) => {
                context.Request.EnableBuffering();
                await next();
            });

            return app;
        }
    }
}
