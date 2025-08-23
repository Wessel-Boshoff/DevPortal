using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class EditUserRequest : IRequest<EditUserResponse>
    {
        public User User { get; set; } = new();
    }
}
