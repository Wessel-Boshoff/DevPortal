using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAppPortalApi.Data.Database;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Data.Stores.RequestLogs;
using WebAppPortalApi.Data.Stores.EventLogs;
using WebAppPortalApi.Providers;
using WebAppPortalApi.Middleware;

namespace WebAppPortalApi.Extensions
{
    public static class RequestLogExtensions
    {
        public static WebApplication UseRequestLogExtensions(this WebApplication app)
        {
            app.UseMiddleware<RequestMiddleware>();
            return app;
        }
    }
}
