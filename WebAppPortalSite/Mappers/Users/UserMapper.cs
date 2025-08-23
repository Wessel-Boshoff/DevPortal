using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models.Users;
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

        internal static User Map(this UserViewModel model) => model == default ? new() : new()
        {
            EmailAddress = model.EmailAddress,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
            Role = model.Role,
            Moniker = model.Moniker
        };


        internal static List<UserViewModel> Map(this List<UserMinimal> model) => model == default ? [] : [.. model.Select(c => c.Map())];
        internal static UserViewModel Map(this UserMinimal model) => model == default ? new() : new()
        {
            EmailAddress = model.EmailAddress,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
            Role = model.Role,
            Moniker = model.Moniker
        };

        internal static UserViewModel MapUser(this User model) => model == default ? new() : new()
        {
            EmailAddress = model.EmailAddress,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
            Role = model.Role,
            Moniker = model.Moniker
        };

    }
}
