using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppPortalApi.Common.Models.Users
{

    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(254, ErrorMessage = "Email address cannot exceed 254 characters.")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "First names are required.")]
        [MinLength(2, ErrorMessage = "First names must be at least 2 characters long.")]
        [MaxLength(300, ErrorMessage = "First names cannot exceed 300 characters.")]
        public string? FirstNames { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long.")]
        [MaxLength(300, ErrorMessage = "Last name cannot exceed 300 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; } 
        public SelectList? Roles { get; set; }
        public Guid Moniker { get; set; }
    }

}
