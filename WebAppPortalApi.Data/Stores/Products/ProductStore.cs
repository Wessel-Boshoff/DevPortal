using Microsoft.EntityFrameworkCore;
using WebAppPortalApi.Database;
using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Products
{
    public class ProductStore : StoreBase, IProductStore
    {
        public ProductStore(DBContext context) : base(context)
        {

        }

        public async Task<Product> Get(Guid moniker, CancellationToken cancellationToken) =>
            await context.Products.Include(c => c.User).SingleAsync(c => c.Moniker == moniker, cancellationToken);

        public async Task<List<Product>> Get(CancellationToken cancellationToken) =>
            await context.Products.ToListAsync(cancellationToken);

        public async Task<bool> Exists(Guid moniker, CancellationToken cancellationToken) =>
            await context.Products.AnyAsync(c => c.Moniker == moniker, cancellationToken);

        public async Task Remove(Product entity, CancellationToken cancellationToken)
        {
            context.Products.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product> Add(Product entity, CancellationToken cancellationToken)
        {
            try
            {
                context.Products.Add(entity);
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
