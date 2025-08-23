using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class AddProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
