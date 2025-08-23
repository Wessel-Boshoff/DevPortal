using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;
using System.Web.Mvc;


namespace WebAppPortalSite.Common.Models.Users
{

    using System.ComponentModel.DataAnnotations;

    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required.")]  
        public string? Password { get; set; }
    }

}
