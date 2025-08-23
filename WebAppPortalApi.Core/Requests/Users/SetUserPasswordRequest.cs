using MediatR;
using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class SetUserPasswordRequest : IRequest<SetUserPasswordResponse>
    {
        public Login Login { get; set; } = new();
    }
}
