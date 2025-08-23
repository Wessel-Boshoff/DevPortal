
using WebAppPortalSite.Database.Tables.log;

namespace WebAppPortalSite.Core.Handlers.RequestLogs
{
    public interface IRequestLoggerHandler
    {
        void LogRequest(Request entity);
    }
}