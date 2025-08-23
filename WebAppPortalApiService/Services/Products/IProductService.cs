using WebAppPortalApiService.Models.Products;
using WebAppPortalApiService.Requests.Products;

namespace WebAppPortalApiService.Services.Products
{
    public interface IProductService
    {
        Task<AddProductResponse> Add(Product request, CancellationToken cancellationToken, string token);
        Task<RemoveProductResponse> Delete(Guid moniker, CancellationToken cancellationToken, string token);
        Task<EditProductResponse> Edit(Product request, CancellationToken cancellationToken, string token);
        Task<GetProductsResponse> Get(CancellationToken cancellationToken, string token);
        Task<GetProductResponse> Get(Guid moniker, CancellationToken cancellationToken, string token);
    }
}