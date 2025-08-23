using WebAppPortalApiService.Models.Dashboards;
namespace WebAppPortalSite.Mappers.Dashboards
{
    internal static class SummaryMapper
    {
        internal static Common.Models.Dashboards.Summary MapSummary(this Summary model) => model == default ? new() : new()
        {
            TopWeeklyUser = model.TopWeeklyUser,
            TotalActiveUsers = model.TotalActiveUsers,
            TotalProducts = model.TotalProducts,
            TotalUsers = model.TotalUsers
        };

    }
}
