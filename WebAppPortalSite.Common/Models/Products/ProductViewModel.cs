using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppPortalSite.Common.Models.Products
{
    public class ProductViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name are required.")]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters.")]
        public string? Name { get; set; }
        public string? ImageBase64Thumbnail { get; set; }
        public Guid Moniker { get; set; }
        [DisplayName("Description")]
        [MaxLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string? Description { get; set; }
        [DisplayName("Image")]
        public string? ImageBase64 { get; set; }
        public string? Extension { get; set; }
        public DateTime Created { get; set; }
        public string? UserEmailAddress { get; set; }
        public string? UserFirstNames { get; set; }
        public string? UserLastName { get; set; }
        [DisplayName("User")]
        [Required(ErrorMessage = "User is required.")]
        public Guid UserMoniker { get; set; }
        public SelectList? Users { get; set; }
    }
}