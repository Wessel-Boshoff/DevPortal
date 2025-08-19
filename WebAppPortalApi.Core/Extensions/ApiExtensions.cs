using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Data.Stores.RequestLogs;
using WebAppPortalApi.Core.Handlers.RequestLogs;
using Microsoft.AspNetCore.Builder;
using WebAppPortalApi.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;
using WebAppPortalApi.Database.Extensions;
using WebAppPortalApi.Core.Utilities.Auths;

using WebAppPortalApi.Common.Options;

namespace WebAppPortalApi.Core.Extensions
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
