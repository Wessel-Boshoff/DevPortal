using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
