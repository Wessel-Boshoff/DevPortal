using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalApi.Data.Database.Tables.log;
using WebAppPortalApi.Data.Stores.EventLogs;
using WebAppPortalApi.Data.Stores.RequestLogs;

namespace WebAppPortalApi.Core.Handlers.RequestLogs
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
