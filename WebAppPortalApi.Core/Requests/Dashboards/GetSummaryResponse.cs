using WebAppPortalApi.Common.Models.Dashboards;

namespace WebAppPortalApi.Core.Requests.Dashboards
{
    public class GetSummaryResponse : BaseResponse
    {
        public Summary Summary { get; set; } = new();
    }
}
