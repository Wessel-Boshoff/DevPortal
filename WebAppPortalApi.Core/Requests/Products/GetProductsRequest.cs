using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Products
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
    }
}
