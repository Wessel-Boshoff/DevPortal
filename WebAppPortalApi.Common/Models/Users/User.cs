using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Common.Models.Users
{
    public class User
    {
        public string? EmailAddress { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastSignIn { get; set; }
    }
}
