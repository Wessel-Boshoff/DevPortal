using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;

namespace WebAppPortalSite.Common.Models.Users
{
    public class UserMinimal
    {
        public string? EmailAddress { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public Guid Moniker { get; set; }
        public Role Role { get; set; }

    }
}
