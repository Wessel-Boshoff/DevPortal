using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortal.Tests.Mock.Stores
{
    public class RequestLogStore : WebAppPortalApi.Data.Stores.RequestLogs.IRequestLogStore
    {
        public async Task<Request> Add(Request entity, CancellationToken cancellationToken) =>
          await Task.Run(() => { return TestEntities.Request(); });
    }
}
