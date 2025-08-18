using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;

using WebAppPortalApi.Core.Middleware;
using Microsoft.AspNetCore.Builder;

namespace WebAppPortalApi.Core.Extensions
{
    internal static class RequestLogExtensions
    {
        internal static WebApplication UseRequestLogExtensions(this WebApplication app)
        {
            app.UseMiddleware<RequestMiddleware>();
            return app;
        }
    }
}
