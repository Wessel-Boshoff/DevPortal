using MediatR;
using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public Product Product { get; set; } = new();
    }
}
