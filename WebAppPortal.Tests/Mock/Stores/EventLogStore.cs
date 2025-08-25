

using System.Reflection.Metadata.Ecma335;
using WebAppPortalApi.Data.Stores.EventLogs;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortal.Tests.Mock.Stores
{
    public class EventLogStore :  IEventLogStore
    {
        public EventLogStore()
        {

        }

        public async Task<Event> Add(Event entity, CancellationToken cancellationToken) =>
            await Task.Run(() => { return entity; });
    }
}
