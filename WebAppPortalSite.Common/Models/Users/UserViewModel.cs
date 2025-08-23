using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppPortalSite.Common.Enums;

namespace WebAppPortalSite.Common.Models.Users
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(254, ErrorMessage = "Email address cannot exceed 254 characters.")]
        public string? EmailAddress { get; set; }

        [DisplayName("First Names")]
        [Required(ErrorMessage = "First names are required.")]
        [MinLength(2, ErrorMessage = "First names must be at least 2 characters long.")]
        [MaxLength(300, ErrorMessage = "First names cannot exceed 300 characters.")]
        public string? FirstNames { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long.")]
        [MaxLength(300, ErrorMessage = "Last name cannot exceed 300 characters.")]
        public string? LastName { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; }
        public SelectList? Roles { get; set; }
        public Guid Moniker { get; set; }
    }

}
