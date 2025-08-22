
using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Requests.Users
{
    public class RemoveUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
