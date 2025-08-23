using Microsoft.EntityFrameworkCore;
using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Users
{
    public class UserStore : StoreBase, IUserStore
    {
        public UserStore(DBContext context) : base(context)
        {

        }

        public async Task<User> Get(string emailAddress, CancellationToken cancellationToken) =>
           await context.Users.SingleAsync(c => c.EmailAddress == emailAddress, cancellationToken);

        public async Task<User> Get(Guid moniker, CancellationToken cancellationToken) =>
            await context.Users.SingleAsync(c => c.Moniker == moniker, cancellationToken);

        public async Task<List<User>> Get(CancellationToken cancellationToken) =>
            await context.Users.Include(c => c.Products).ToListAsync(cancellationToken);

        public async Task<bool> Exists(Guid moniker, CancellationToken cancellationToken) =>
            await context.Users.AnyAsync(c => c.Moniker == moniker, cancellationToken);

        public async Task<bool> Exists(string emailAddress, CancellationToken cancellationToken) =>
            await context.Users.AnyAsync(c => c.EmailAddress == emailAddress, cancellationToken);

        public async Task<User> Get(int id, CancellationToken cancellationToken) =>
            await context.Users.SingleAsync(c => c.Id == id, cancellationToken);

        public async Task Remove(User entity, CancellationToken cancellationToken)
        {
            context.Users.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }


        public async Task<User> Add(User entity, CancellationToken cancellationToken)
        {
            try
            {
                context.Users.Add(entity);
                await SaveChanges(cancellationToken);
                return entity;
            }
            catch (Exception)
            {
                context.Remove(entity);
                throw;
            }
        }

        public async Task SaveChanges(CancellationToken cancellationToken) =>
            await context.SaveChangesAsync(cancellationToken);
    }
}
