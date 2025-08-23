using WebAppPortalApi.Common.Models.Dashboards;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Core.Extensions
{
    public static class SummaryExtensions
    {

        public static Summary CalculateSummary(this List<User> users)
        {
            Summary summary = new();
            if (users == null)
            {
                return summary;
            }

            summary.TotalUsers = users.Count;
            summary.TotalActiveUsers = users.Count(c => c.LastSignIn < DateTime.Now.AddDays(30));
            var userTop = users
            .Where(u => u.LastSignIn >= DateTime.Now.AddDays(-7))
            .OrderByDescending(u => u.Products.Count)
            .FirstOrDefault();

            if (userTop != default)
            {
                summary.TopWeeklyUser = $"{userTop.FirstNames} {userTop.LastName}";
            }

            summary.TotalProducts = users.SelectMany(c => c.Products).Count();

            return summary;
        }

    }
}
