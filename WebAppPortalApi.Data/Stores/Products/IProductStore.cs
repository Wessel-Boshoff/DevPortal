using WebAppPortalApi.Database.Tables.dbo;

namespace WebAppPortalApi.Data.Stores.Products
{
    public interface IProductStore
    {
        Task<Product> Add(Product entity, CancellationToken cancellationToken);
        Task<bool> Exists(Guid moniker, CancellationToken cancellationToken);
        Task<List<Product>> Get(CancellationToken cancellationToken);
        Task<Product> Get(Guid moniker, CancellationToken cancellationToken);
        Task Remove(Product entity, CancellationToken cancellationToken);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}