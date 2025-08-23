using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class EditProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
