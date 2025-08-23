using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class GetProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
