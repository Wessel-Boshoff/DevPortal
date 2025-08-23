using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalSite.Data.Stores.Users;
using WebAppPortalSite.Data.Stores.RequestLogs;
using WebAppPortalSite.Core.Handlers.RequestLogs;
using Microsoft.AspNetCore.Builder;
using WebAppPortalSite.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalSite.Database.Extensions;
using WebAppPortalSite.Core.Utilities.Auths;

using WebAppPortalSite.Common.Options;

namespace WebAppPortalSite.Core.Extensions
{
    public static class ApiExtensions
    {
        public static WebApplicationBuilder AddApiExtensions(this WebApplicationBuilder builder)
        {
            builder.AddDataExtensions();
            builder.AddDatabaseExtensions();
            builder.AddEventLogExtensions();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddFluentValidationAutoValidation(delegate
            {
            });

            builder.Services.AddHealthChecks();

            //Handlers
            builder.Services.AddScoped<IRequestLoggerHandler, RequestLoggerHandler>();

            //Utilities
            builder.Services.AddScoped<IAuthUtility, AuthUtility>();

            //Options
            builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection(nameof(JwtTokenOptions)));

            return builder;
        }

        public static WebApplication UseApiExtensions(this WebApplication app)
        {
            app.MapHealthChecks("/health");
            app.UseRequestLogExtensions();
            app.UseEventLogExtensions();

            return app;
        }
    }
}
