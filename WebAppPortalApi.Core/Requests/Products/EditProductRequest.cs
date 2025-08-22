using MediatR;
using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class EditProductRequest : IRequest<EditProductResponse>
    {
        public Product Product { get; set; } = new();
    }
}
