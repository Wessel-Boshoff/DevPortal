using Microsoft.EntityFrameworkCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortal.Tests.Mock.Stores
{
    public class UserStore : IUserStore
    {
        public bool MockExist { get; set; } = true;

        public async Task<User> Get(string emailAddress, CancellationToken cancellationToken) =>
           await Task.Run(() => { return TestEntities.User(); });

        public async Task<User> Get(Guid moniker, CancellationToken cancellationToken) =>
                await Task.Run(() => { return TestEntities.User(); });

        public async Task<List<User>> Get(CancellationToken cancellationToken) =>
                await Task.Run(() => { return new List<User>() { TestEntities.User(), TestEntities.User() }; });

        public async Task<bool> Exists(Guid moniker, CancellationToken cancellationToken) =>
       await Task.Run(() => { return MockExist; });

        public async Task<bool> Exists(string emailAddress, CancellationToken cancellationToken) =>
         await Task.Run(() => { return MockExist; });

        public async Task<User> Get(int id, CancellationToken cancellationToken) =>
               await Task.Run(() => { return TestEntities.User(); });

        public async Task Remove(User entity, CancellationToken cancellationToken) =>
            await Task.Run(() => { return; });


        public async Task<User> Add(User entity, CancellationToken cancellationToken) =>
         await Task.Run(() => { return entity; });

        public async Task SaveChanges(CancellationToken cancellationToken) =>
        await Task.Run(() => { return; });
    }
}
