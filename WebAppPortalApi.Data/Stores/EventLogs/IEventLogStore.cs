using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Data.Stores.EventLogs
{
    public interface IEventLogStore
    {
        Task<Event> Add(Event entity, CancellationToken cancellationToken);
    }
}