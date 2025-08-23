using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Data.Stores.EventLogs
{
    public class EventLogStore : StoreBase, IEventLogStore
    {
        public EventLogStore(DBContext context) : base(context)
        {

        }

        public async Task<Event> Add(Event entity, CancellationToken cancellationToken)
        {
            try
            {
                context.Events.Add(entity);
                await context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception)
            {
                context.Remove(entity);
                throw;
            }
        }
    }
}
