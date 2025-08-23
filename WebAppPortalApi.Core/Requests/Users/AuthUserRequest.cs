using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class AuthUserRequest : IRequest<AuthUserResponse>
    {
        public Login Login { get; set; } = new();
    }
}
