using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
