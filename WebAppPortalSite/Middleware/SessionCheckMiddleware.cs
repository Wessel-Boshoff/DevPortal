using Microsoft.AspNetCore.Authentication;
using WebAppPortalSite.Extensions;

namespace WebAppPortalSite.Middleware
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("AuthToken") && !context.HasSession())
            {
                await context.SignOutAsync();
                context.Response.Redirect("/Account/Login");
                return;
            }

            await _next(context);
        }
    }

}
