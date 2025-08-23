using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Users
{
    public interface IUserStore
    {
        Task<User> Add(User entity, CancellationToken cancellationToken);
        Task<bool> Exists(Guid moniker, CancellationToken cancellationToken);
        Task<bool> Exists(string emailAddress, CancellationToken cancellationToken);
        Task<List<User>> Get(CancellationToken cancellationToken);
        Task<User> Get(Guid moniker, CancellationToken cancellationToken);
        Task<User> Get(int id, CancellationToken cancellationToken);
        Task<User> Get(string emailAddress, CancellationToken cancellationToken);
        Task Remove(User entity, CancellationToken cancellationToken);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}