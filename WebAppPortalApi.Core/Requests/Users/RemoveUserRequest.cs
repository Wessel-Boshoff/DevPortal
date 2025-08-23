using MediatR;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public Guid Moniker { get; set; }
    }
}
