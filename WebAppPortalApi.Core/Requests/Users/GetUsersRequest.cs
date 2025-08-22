using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}
