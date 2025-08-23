using WebAppPortalApiService.Models.Users;

namespace WebAppPortalApiService.Requests.Users
{
    public class GetUsersResponse : BaseResponse
    {
        public List<UserMinimal> Users { get; set; } = [];
    }
}
