using WebAppPortalApiService.Models.Products;
using WebAppPortalApiService.Requests.Products;

namespace WebAppPortalApiService.Services.Products
{
    public interface IProductService
    {
        Task<AddProductResponse> Add(Product request, CancellationToken cancellationToken);
        Task<RemoveProductResponse> Delete(Guid moniker, CancellationToken cancellationToken);
        Task<EditProductResponse> Edit(Product request, CancellationToken cancellationToken);
        Task<GetProductsResponse> Get(CancellationToken cancellationToken);
        Task<GetProductResponse> Get(Guid moniker, CancellationToken cancellationToken);
    }
}