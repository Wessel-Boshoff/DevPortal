using WebAppPortalApiService.Requests.Dashboards;

namespace WebAppPortalApiService.Services.Dashboards
{
    public class DashboardService : IDashboardService
    {
        private readonly ApiService apiService;

        public DashboardService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<GetSummaryResponse> Get(CancellationToken cancellationToken, string token) =>
            await apiService.Get<GetSummaryResponse>("Dashboards", cancellationToken, token) ?? new();
    }
}
