using MediatR;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public Guid Moniker { get; set; }
    }
}
