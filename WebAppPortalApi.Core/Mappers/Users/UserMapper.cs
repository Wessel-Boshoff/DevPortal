using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Mappers.Users
{
    internal static class UserMapper
    {
        /// <summary>
        /// purposely demonstrating implicit casting of complex objects 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        internal static List<UserMinimal> Map(this List<Database.Tables.dbo.User> models) => models == default ? [] : [.. models.Select(c => c.Map())];

        internal static User Map(this Database.Tables.dbo.User entity) => entity == default ? new() : new()
        {
            Created = entity.Created,
            LastSignIn = entity.LastSignIn,
            EmailAddress = entity.EmailAddress,
            FirstNames = entity.FirstNames,
            LastName = entity.LastName,
            Moniker = entity.Moniker,
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
            Moniker = Guid.NewGuid(),
        };

        internal static Database.Tables.dbo.User MapEdit(this Database.Tables.dbo.User entity, User model)
        {
            if (entity == default)
            {
                return entity ?? new();
            }

            entity.EmailAddress = model.EmailAddress;
            entity.FirstNames = model.FirstNames;
            entity.LastName = model.LastName;
            entity.Role = model.Role;

            return entity;
        }

    }
}
