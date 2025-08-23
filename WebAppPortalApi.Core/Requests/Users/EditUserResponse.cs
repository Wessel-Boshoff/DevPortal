using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class EditUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
