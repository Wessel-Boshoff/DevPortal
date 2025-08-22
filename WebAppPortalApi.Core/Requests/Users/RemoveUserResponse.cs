using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class RemoveUserResponse : BaseResponse
    {
        public User User { get; set; } = new();
    }
}
