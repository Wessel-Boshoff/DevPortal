
using WebAppPortalSite.Database.Tables.log;

namespace WebAppPortalSite.Data.Stores.EventLogs
{
    public interface IEventLogStore
    {
        Task<Event> Add(Event entity, CancellationToken cancellationToken);
    }
}