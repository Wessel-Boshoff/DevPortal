
using WebAppPortalApiService.Models.Dashboards;

namespace WebAppPortalApiService.Requests.Dashboards
{
    public class GetSummaryResponse : BaseResponse
    {
        public Summary Summary { get; set; } = new();
    }
}
