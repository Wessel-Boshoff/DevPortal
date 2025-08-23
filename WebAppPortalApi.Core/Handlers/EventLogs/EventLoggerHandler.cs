using Microsoft.Extensions.Logging;
using WebAppPortalApi.Core.Mappers.Logs;
using WebAppPortalApi.Data.Stores.EventLogs;

namespace WebAppPortalApi.Core.Handlers.EventLogs
{
    public class EventLoggerHandler : ILogger
    {
        private static readonly object lockobj = new();
        private readonly IEventLogStore eventLogStore;

        public EventLoggerHandler(IEventLogStore eventLogStore)
        {
            this.eventLogStore = eventLogStore;
        }

        public IDisposable? BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (lockobj)
            {
                Task.WaitAll(
                [
                    Task.Run(() => eventLogStore.Add(logLevel.Map(state?.ToString(), exception), CancellationToken.None))
                ]);
            }
        }
    }
}
