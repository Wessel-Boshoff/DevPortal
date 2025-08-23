using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public Product Product { get; set; } = new();
    }
}
