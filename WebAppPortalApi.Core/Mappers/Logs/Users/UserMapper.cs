using FluentValidation.Results;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Common.Models;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Mappers.Logs.Users
{
    internal static class UserMapper
    {
        //  internal static List<Error> Map(this List<ValidationFailure> models) => models == default ? [] : [.. models.Select(c => c.Map())];

        internal static User Map(this Database.Tables.dbo.User entity) => entity == default ? new() : new()
        {
            Created = entity.Created,
            LastSignIn = entity.LastSignIn,
            EmailAddress = entity.EmailAddress,
            FirstNames = entity.FirstNames,
            LastName = entity.LastName,
            Role = entity.Role,
        };

        internal static Database.Tables.dbo.User MapAdd(this User model) => model == default ? new() : new()
        {
            Created = DateTime.Now,
            EmailAddress = model.EmailAddress,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
            RegistrationStatus = model.Role == Role.Root ? RegistrationStatus.Full : RegistrationStatus.NeedPassword,
            Role = model.Role,
        };

    }
}
