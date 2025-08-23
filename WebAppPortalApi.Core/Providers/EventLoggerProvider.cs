using Microsoft.Extensions.Logging;
using WebAppPortalApi.Core.Handlers.EventLogs;
using WebAppPortalApi.Data.Stores.EventLogs;

namespace WebAppPortalApi.Core.Providers
{
    public class EventLoggerProvider : ILoggerProvider
    {
        private readonly IEventLogStore eventLogStore;

        public EventLoggerProvider(IEventLogStore eventLogStore)
        {
            this.eventLogStore = eventLogStore;
        }

        public ILogger CreateLogger(string categoryName) =>
            new EventLoggerHandler(eventLogStore);

        public void Dispose()
        {

        }
    }
}
