using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public Guid Moniker { get; set; } 
    }
}
