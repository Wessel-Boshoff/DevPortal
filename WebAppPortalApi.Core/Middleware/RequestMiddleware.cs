using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using WebAppPortalApi.Core.Handlers.RequestLogs;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Core.Middleware
{
    public class RequestMiddleware
    {




        private readonly RequestDelegate Next;
        private readonly List<string> exclusions =
        [
            ".png",
            ".ico",
            ".jpg",
            ".css",
            ".js",
            ".mp4",
            ".mp3",
            ".js",
            "/swagger/index.html",
            "/swagger/v1/swagger.json",
        ];

        public RequestMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task Invoke(HttpContext context, IRequestLoggerHandler requestLoggerHandler, ILogger<RequestMiddleware> logger)
        {
            using (var memoryStream = new MemoryStream())
            {
                var streamResponse = context.Response.Body;
                context.Response.Body = memoryStream;

                Request request = new();

                try
                {
                    request.HttpMethod = context.Request.Method;
                    request.RequestDate = DateTime.Now;
                    request.RequestHeaders = string.Join(", ", context.Request.Headers.Select(c => $"{c.Key}: {c.Value}"));
                    request.Url = context.Request.GetEncodedPathAndQuery();
                    context.Request.EnableBuffering();
                    if (context.Request.Body.CanRead)
                    {
                        using (MemoryStream stream = new())
                        {
                            await context.Request.Body.CopyToAsync(stream);
                            context.Request.Body.Position = 0;
                            string body = Encoding.UTF8.GetString(stream.ToArray());
                            request.RequestBody = body;
                            await Next(context);
                        }
                    }
                    else
                    {
                        await Next(context);
                    }

                    string bodyResponse = Encoding.UTF8.GetString(memoryStream.ToArray());
                    request.ResponseBody = bodyResponse;
                    request.HttpStatusCode = (HttpStatusCode)context.Response.StatusCode;
                    request.ResponseDate = DateTime.Now;
                    request.TimeTaken = request.ResponseDate - request.RequestDate;
                    request.ResponseHeaders = string.Join(", ", context.Response.Headers.Select(c => $"{c.Key}: {c.Value}"));

                    memoryStream.Position = 0;
                    await streamResponse.WriteAsync(memoryStream.ToArray());

                }
                catch (Exception ex)
                {
                    request.ResponseBody = ex.ToString();
                    request.HttpStatusCode = HttpStatusCode.InternalServerError;

                    throw;
                }
                finally
                {
                    context.Response.Body = streamResponse;
                    try
                    {
                        if (!exclusions.Any(c => request.Url.ToLower().Contains(c)))
                        {
                            requestLoggerHandler.LogRequest(request);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, ex.Message);
                    }
                }
            }
        }
    }
}