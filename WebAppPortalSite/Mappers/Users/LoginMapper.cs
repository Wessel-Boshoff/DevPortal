using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Models.Users;
namespace WebAppPortalSite.Mappers.Users
{
    internal static class LoginMapper
    {
        internal static Login Map(this LoginUserViewModel model) => model == default ? new() : new()
        {
            EmailAddress = model.EmailAddress,
            Password = model.Password
        };

        internal static Login Map(this SetPasswordViewModel model) => model == default ? new() : new()
        {
            EmailAddress = model.EmailAddress,
            Password = model.Password
        };
    }
}
