
using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Requests.Users
{
    public class EditUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
