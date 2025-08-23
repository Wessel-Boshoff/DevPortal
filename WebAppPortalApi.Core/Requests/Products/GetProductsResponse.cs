using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class GetProductsResponse : BaseResponse
    {
        public List<ProductMinimal> Products { get; set; } = [];
    }
}
