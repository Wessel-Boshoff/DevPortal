using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;

namespace WebAppPortalSite.Common.Models.Users
{
    public class Login
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }

    }
}
