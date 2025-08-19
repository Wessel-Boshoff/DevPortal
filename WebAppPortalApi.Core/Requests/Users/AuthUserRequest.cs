using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class AuthUserRequest : IRequest<AuthUserResponse>
    {
        public Login Login { get; set; } = new();
    }
}
