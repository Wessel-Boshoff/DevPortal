using WebAppPortalApiService.Requests.Dashboards;

namespace WebAppPortalApiService.Services.Dashboards
{
    public interface IDashboardService
    {
        Task<GetSummaryResponse> Get(CancellationToken cancellationToken, string token);
    }
}