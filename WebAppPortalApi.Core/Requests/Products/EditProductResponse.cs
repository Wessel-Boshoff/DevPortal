using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class EditProductResponse : BaseResponse
    {
        public Product Product { get; set; } = new();
    }
}
