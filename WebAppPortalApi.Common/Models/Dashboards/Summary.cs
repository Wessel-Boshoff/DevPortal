namespace WebAppPortalApi.Common.Models.Dashboards
{
    public class Summary
    {
        public int TotalUsers { get; set; }
        public int TotalActiveUsers { get; set; }
        public int TotalProducts { get; set; }
        public string? TopWeeklyUser { get; set; }

    }
}
