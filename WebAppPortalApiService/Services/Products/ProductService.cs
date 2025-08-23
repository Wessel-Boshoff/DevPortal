using WebAppPortalApiService.Models.Products;
using WebAppPortalApiService.Requests.Products;

namespace WebAppPortalApiService.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ApiService apiService;

        public ProductService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<GetProductsResponse> Get(CancellationToken cancellationToken) =>
            await apiService.Get<GetProductsResponse>("Products", cancellationToken) ?? new();

        public async Task<GetProductResponse> Get(Guid moniker, CancellationToken cancellationToken) =>
           await apiService.Get<GetProductResponse>($"Products/{moniker}", cancellationToken) ?? new();

        public async Task<RemoveProductResponse> Delete(Guid moniker, CancellationToken cancellationToken) =>
           await apiService.Delete<RemoveProductResponse>($"Products/{moniker}", cancellationToken) ?? new();

        public async Task<EditProductResponse> Edit(Product request, CancellationToken cancellationToken) =>
           await apiService.Put<Product, EditProductResponse>("Products", request, cancellationToken) ?? new();

        public async Task<AddProductResponse> Add(Product request, CancellationToken cancellationToken) =>
           await apiService.Post<Product, AddProductResponse>("Products", request, cancellationToken) ?? new();


    }
}
