using WebAppPortalApi.Data.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Users
{
    public interface IUserStore
    {
        Task<User> Add(User entity, CancellationToken cancellationToken);
    }
}