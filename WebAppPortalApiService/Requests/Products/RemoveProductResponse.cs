using WebAppPortalApiService.Models.Products;

namespace WebAppPortalApiService.Requests.Products
{
    public class RemoveProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
