using Microsoft.Extensions.Logging;
using System;
using WebAppPortalSite.Core.Handlers.EventLogs;
using WebAppPortalSite.Data.Stores.EventLogs;

namespace WebAppPortalSite.Core.Providers
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
