using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Requests.Users
{
    public class AddUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
        public Auth Auth { get; set; } = new();
    }
}
