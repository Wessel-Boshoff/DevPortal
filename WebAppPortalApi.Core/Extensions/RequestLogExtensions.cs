using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;

using WebAppPortalSite.Core.Middleware;
using Microsoft.AspNetCore.Builder;

namespace WebAppPortalSite.Core.Extensions
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
