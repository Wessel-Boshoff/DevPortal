using MediatR;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public Guid Moniker { get; set; }
    }
}
