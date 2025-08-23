using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalSite.Data.Stores.EventLogs;
using WebAppPortalSite.Data.Stores.RequestLogs;
using WebAppPortalSite.Database.Tables.log;

namespace WebAppPortalSite.Core.Handlers.RequestLogs
{
    public class RequestLoggerHandler : IRequestLoggerHandler
    {
        private static readonly object lockobj = new();
        private readonly IRequestLogStore requestLogStore;
        public RequestLoggerHandler(IRequestLogStore requestLogStore)
        {
            this.requestLogStore = requestLogStore;
        }

        public void LogRequest(Request entity)
        {
            lock (lockobj)
            {
                Task.WaitAll(
                [
                    Task.Run(() => requestLogStore.Add(entity, CancellationToken.None))
                ]);
            }
        }
    }
}
