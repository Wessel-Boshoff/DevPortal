using WebAppPortalApiService.Models.Products;

namespace WebAppPortalApiService.Requests.Products
{
    public class EditProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
