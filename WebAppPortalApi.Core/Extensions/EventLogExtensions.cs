using Microsoft.EntityFrameworkCore;
using System.Reflection;

using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalSite.Core.Providers;
using WebAppPortalSite.Data.Stores.EventLogs;
using Microsoft.AspNetCore.Http;

namespace WebAppPortalSite.Core.Extensions
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
            app.Use(async (context, next) => {
                context.Request.EnableBuffering();
                await next();
            });

            return app;
        }
    }
}
