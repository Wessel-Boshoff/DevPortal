using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Users
{
    public class UserStore : StoreBase, IUserStore
    {
        public UserStore(DBContext context) : base(context)
        {

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
    }
}
