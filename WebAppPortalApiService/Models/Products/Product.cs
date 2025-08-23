using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Models.Products
{
    public class Product : ProductMinimal
    {
        public string? Description { get; set; }
        public string? ImageBase64 { get; set; }

        public DateTime Created { get; set; }
        public User User { get; set; } = new();
    }
}
