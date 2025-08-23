using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public User User { get; set; } = new();
    }
}
