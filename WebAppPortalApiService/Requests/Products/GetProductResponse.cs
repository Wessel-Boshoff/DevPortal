using WebAppPortalApiService.Models.Products;


namespace WebAppPortalApiService.Requests.Products
{
    public class GetProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
