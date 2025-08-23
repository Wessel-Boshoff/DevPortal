using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Models;
namespace WebAppPortalSite.Mappers.Users
{
    internal static class PrimarySessionMapper
    {
        internal static PrimarySession Map(this User model, string token) => model == default ? new() : new()
        {
            ApiToken = token,
            FirstNames = model.FirstNames,
            LastName = model.LastName,
        };
    }
}
