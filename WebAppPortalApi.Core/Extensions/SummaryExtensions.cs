using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalSite.Common.Models.Dashboards;
using WebAppPortalSite.Common.Resources;
using WebAppPortalSite.Database.Tables.dbo;

namespace WebAppPortalSite.Extensions
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
