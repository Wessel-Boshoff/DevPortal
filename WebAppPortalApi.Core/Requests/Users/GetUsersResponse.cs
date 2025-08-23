using WebAppPortalSite.Common.Models.Users;

namespace WebAppPortalSite.Core.Requests.Users
{
    public class GetUsersResponse : BaseResponse
    {
        public List<UserMinimal> Users { get; set; } = [];
    }
}
