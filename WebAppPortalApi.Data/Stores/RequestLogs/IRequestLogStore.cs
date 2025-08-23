using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortalApi.Data.Stores.RequestLogs
{
    public interface IRequestLogStore
    {
        Task<Request> Add(Request entity, CancellationToken cancellationToken);
    }
}