using MediatR;
using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
