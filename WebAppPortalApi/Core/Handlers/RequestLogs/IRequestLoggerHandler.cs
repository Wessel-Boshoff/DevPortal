using WebAppPortalApi.Data.Database.Tables.log;

namespace WebAppPortalApi.Core.Handlers.RequestLogs
{
    public interface IRequestLoggerHandler
    {
        void LogRequest(Request entity);
    }
}