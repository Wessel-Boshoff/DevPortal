using WebAppPortalApi.Common.Models.Users;

namespace WebAppPortalApi.Core.Utilities.Auths
{
    public interface IAuthUtility
    {
        Task<Tuple<Auth, Database.Tables.dbo.User>> Authenticate(string emailAddress, string password, CancellationToken cancellationToken);
        Task<Database.Tables.dbo.User> CaptureAuthProfile(Database.Tables.dbo.User user, string password, CancellationToken cancellationToken);
    }
}