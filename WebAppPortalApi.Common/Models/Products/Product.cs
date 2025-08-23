using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Common.Models.Products
{
    public class Product : ProductMinimal
    {
        public string? Description { get; set; }
        public string? ImageBase64 { get; set; }

        public DateTime Created { get; set; }
        public User User { get; set; } = new();
    }
}
