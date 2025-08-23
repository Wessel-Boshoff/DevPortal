using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class AuthUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
        public Auth Auth { get; set; } = new();
    }
}
