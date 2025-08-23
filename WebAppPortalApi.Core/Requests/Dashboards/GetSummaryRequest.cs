using MediatR;
using WebAppPortalSite.Common.Models.Products;

namespace WebAppPortalSite.Core.Requests.Dashboards
{
    public class GetSummaryRequest : IRequest<GetSummaryResponse>
    {
    }
}
