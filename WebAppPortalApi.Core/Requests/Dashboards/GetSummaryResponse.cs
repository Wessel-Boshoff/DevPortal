using WebAppPortalSite.Common.Models.Dashboards;

namespace WebAppPortalSite.Core.Requests.Dashboards
{
    public class GetSummaryResponse : BaseResponse
    {
        public Summary Summary { get; set; } = new();
    }
}
