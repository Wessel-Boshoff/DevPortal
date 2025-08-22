using WebAppPortalApiService.Models.Products;

namespace WebAppPortalApiService.Requests.Products
{
    public class GetProductsResponse : BaseResponse
    {
        public List<ProductMinimal> Products { get; set; } = [];
    }
}
