using MediatR;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class SetUserPasswordRequest : IRequest<SetUserPasswordResponse>
    {
        public Login Login { get; set; } = new();
    }
}
