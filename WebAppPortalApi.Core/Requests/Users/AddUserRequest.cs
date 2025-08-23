using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public User User { get; set; } = new();
    }
}
