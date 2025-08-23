using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class RemoveProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
