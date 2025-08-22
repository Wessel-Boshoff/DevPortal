using MediatR;
using WebAppPortalApi.Common.Models.Products;

namespace WebAppPortalApi.Core.Requests.Products
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
    }
}
