
using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Requests.Users
{
    public class GetUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
