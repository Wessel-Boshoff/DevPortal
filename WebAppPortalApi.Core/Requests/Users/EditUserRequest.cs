using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class EditUserRequest : IRequest<EditUserResponse>
    {
        public User User { get; set; } = new();
    }
}
