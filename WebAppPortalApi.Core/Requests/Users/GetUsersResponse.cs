using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Requests.Users
{
    public class GetUsersResponse : BaseResponse
    {
        public List<UserMinimal> Users { get; set; } = [];
    }
}
