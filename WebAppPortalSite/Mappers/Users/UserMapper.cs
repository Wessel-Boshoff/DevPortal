using WebAppPortalApi.Common.Models.Users;
using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Enums;
namespace WebAppPortalSite.Mappers.Users
{
    internal static class UserMapper
    {
        internal static User Map(this RegisterUserViewModel model) => model == default ? new() : new()
        { 
            EmailAddress = model.EmailAddress,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
            Password = model.Password,
            Role = Role.Root
        };
    }
}
