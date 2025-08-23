using WebAppPortalSite.Common.Models.Users;
using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models;
namespace WebAppPortalSite.Mappers.Users
{
    internal static class PrimarySessionMapper
    {
        internal static PrimarySession Map(this User model) => model == default ? new() : new()
        { 
            FirstNames = model.FirstNames,
            LastName = model.LastName,
        };
    }
}
