using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;

namespace WebAppPortalSite.Common.Models.Users
{
    public class User : UserMinimal
    {
        public string? Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastSignIn { get; set; }

    }
}
