using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;
using System.Web.Mvc;


namespace WebAppPortalApi.Common.Models.Users
{

    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel
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

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }

}
