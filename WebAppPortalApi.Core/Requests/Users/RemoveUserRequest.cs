using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
