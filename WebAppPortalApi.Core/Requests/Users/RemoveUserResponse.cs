using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class RemoveUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
