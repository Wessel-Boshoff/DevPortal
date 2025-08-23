using Microsoft.Extensions.Logging;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Core.Mappers.Logs
{
    internal static class EventMapper
    {
        internal static Event Map(this LogLevel logLevel, string? state, Exception? exception) => new()
        {
            Exception = exception?.ToString(),
            LogLevel = logLevel.ToString(),
            State = state,
            TimeStamp = DateTime.Now,
            StackTrace = exception?.StackTrace
        };
    }
}
