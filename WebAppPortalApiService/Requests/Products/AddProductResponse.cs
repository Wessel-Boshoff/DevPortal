using WebAppPortalApiService.Models.Products;


namespace WebAppPortalApiService.Requests.Products
{
    public class AddProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
