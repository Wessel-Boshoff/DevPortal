using Microsoft.Extensions.Logging;
using Sycon.Logging.Data.Stores.Event;

namespace Sycon.Logging.Core.Handlers.Event
{
    public class SyconEventLoggerHandler : ILogger
    {
        private static readonly object lockobj = new (); 
        private readonly IEventLoggerStore EventStore;

        public SyconEventLoggerHandler(IEventLoggerStore eventStore)
        {
            EventStore = eventStore;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return default;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (lockobj)
            {
                EventStore.LogEvent(logLevel, state?.ToString() ?? string.Empty, (int)logLevel > 3 ? exception : null);
            }
        }
    }
}
