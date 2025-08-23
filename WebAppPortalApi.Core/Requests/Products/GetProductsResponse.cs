using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class GetProductsResponse : BaseResponse
    {
        public List<ProductMinimal> Products { get; set; } = [];
    }
}
