using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}
