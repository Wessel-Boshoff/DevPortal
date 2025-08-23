using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class GetUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
