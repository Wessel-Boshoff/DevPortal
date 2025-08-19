using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppPortalApiService.Models.Users
{
    public class Login
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }

    }
}
