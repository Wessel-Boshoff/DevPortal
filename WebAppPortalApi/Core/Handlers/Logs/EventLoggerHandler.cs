using Microsoft.Extensions.Logging;
using WebAppPortalApi.Data.Stores.EventLogs;

namespace Sycon.Logging.Core.Handlers.Event
{
    public class  EventLoggerHandler : ILogger
    {
        private static readonly object lockobj = new (); 
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
                    Task.Run(eventLogStore.Add(logLevel, state?.ToString() ?? string.Empty, (int)logLevel > 3 ? exception : null))
                ]);   
            }
        }
    }
}
