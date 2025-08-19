using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Common.Models.Users
{
    public class Login
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }

    }
}
