using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAppPortalApi.Common.Options;
using WebAppPortalApi.Core.Handlers.RequestLogs;
using WebAppPortalApi.Core.Utilities.Auths;
using WebAppPortalApi.Data.Extensions;
using WebAppPortalApi.Database.Extensions;

namespace WebAppPortalApi.Core.Extensions
{
    public static class ApiExtensions
    {
        public static WebApplicationBuilder AddApiExtensions(this WebApplicationBuilder builder)
        {
            builder.AddDataExtensions();
            builder.AddDatabaseExtensions();
            builder.AddEventLogExtensions();
            builder.AddAuthExtensions();

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
