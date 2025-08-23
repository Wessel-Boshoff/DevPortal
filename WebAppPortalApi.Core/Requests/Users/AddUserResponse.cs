using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class AddUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
        public Auth Auth { get; set; } = new();
    }
}
