using Microsoft.AspNetCore.Builder;
using WebAppPortalApi.Core.Middleware;

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
