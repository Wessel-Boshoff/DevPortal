
using WebAppPortalSite.Database.Tables.log;

namespace WebAppPortalSite.Data.Stores.RequestLogs
{
    public interface IRequestLogStore
    {
        Task<Request> Add(Request entity, CancellationToken cancellationToken);
    }
}