using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAppPortalApi.Data.Database;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Data.Stores.RequestLogs;

namespace WebAppPortalApi.Extensions
{
    public static class ApiExtensions
    {
        public static WebApplicationBuilder AddApiExtensions(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddHealthChecks();

            return builder;
        }

        public static WebApplication UseApiExtensions(this WebApplication app)
        {
            app.MapHealthChecks("/health");

            return app;
        }
    }
}
