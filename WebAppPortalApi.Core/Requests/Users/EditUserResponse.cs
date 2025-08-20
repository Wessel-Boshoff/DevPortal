using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class EditUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
