using WebAppPortalApi.Data.Database;
using WebAppPortalApi.Data.Database.Tables.dbo;
using WebAppPortalApi.Data.Database.Tables.log;

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
                await SaveChanges(cancellationToken);
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
