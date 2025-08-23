using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPortalSite.Common.Models.Dashboards
{
    public class Summary
    {
        public int TotalUsers { get; set; }
        public int TotalActiveUsers { get; set; }
        public int TotalProducts { get; set; }
        public string? TopWeeklyUser { get; set; }

    }
}
