using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class EditProductRequest : IRequest<EditProductResponse>
    {
        public Product Product { get; set; } = new();
    }
}
