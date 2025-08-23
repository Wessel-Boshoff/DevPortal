using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Data.Stores.RequestLogs
{
    public class RequestLogStore : StoreBase, IRequestLogStore
    {
        public RequestLogStore(DBContext context) : base(context)
        {

        }

        public async Task<Request> Add(Request entity, CancellationToken cancellationToken)
        {
            try
            {
                context.Requests.Add(entity);
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
