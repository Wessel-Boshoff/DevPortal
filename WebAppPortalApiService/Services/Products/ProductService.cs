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

        public async Task<GetProductsResponse> Get(CancellationToken cancellationToken, string token) =>
            await apiService.Get<GetProductsResponse>("Products", cancellationToken, token) ?? new();

        public async Task<GetProductResponse> Get(Guid moniker, CancellationToken cancellationToken, string token) =>
           await apiService.Get<GetProductResponse>($"Products/{moniker}", cancellationToken, token) ?? new();

        public async Task<RemoveProductResponse> Delete(Guid moniker, CancellationToken cancellationToken, string token) =>
           await apiService.Delete<RemoveProductResponse>($"Products/{moniker}", cancellationToken, token) ?? new();

        public async Task<EditProductResponse> Edit(Product request, CancellationToken cancellationToken, string token) =>
           await apiService.Put<Product, EditProductResponse>("Products", request, cancellationToken, token) ?? new();

        public async Task<AddProductResponse> Add(Product request, CancellationToken cancellationToken, string token) =>
           await apiService.Post<Product, AddProductResponse>("Products", request, cancellationToken, token) ?? new();


    }
}
