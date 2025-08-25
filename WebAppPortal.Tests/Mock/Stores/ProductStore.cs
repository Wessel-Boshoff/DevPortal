using Microsoft.EntityFrameworkCore;
using WebAppPortalApi.Data.Stores.Products;
using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortal.Tests.Mock.Stores
{
    public class ProductStore : IProductStore
    {
        public async Task<Product> Get(Guid moniker, CancellationToken cancellationToken) =>
          await Task.Run(() => { return TestEntities.Product(); });

        public async Task<List<Product>> Get(CancellationToken cancellationToken) =>
                await Task.Run(() => { return new List<Product>() { TestEntities.Product(), TestEntities.Product() }; });

        public async Task<bool> Exists(Guid moniker, CancellationToken cancellationToken) =>
            await Task.Run(() => { return true; });

        public async Task Remove(Product entity, CancellationToken cancellationToken) =>
           await Task.Run(() => { return; });

        public async Task<Product> Add(Product entity, CancellationToken cancellationToken) =>
            await Task.Run(() => { return entity; });

        public async Task SaveChanges(CancellationToken cancellationToken) =>
           await Task.Run(() => { return; });
    }
}
