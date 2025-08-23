using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
