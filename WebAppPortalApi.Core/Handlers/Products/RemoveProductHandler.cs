using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Core.Validators.Products;
using WebAppPortalApi.Data.Stores.Products;

namespace WebAppPortalApi.Core.Handlers.Products
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IProductStore productStore;

        public RemoveProductHandler(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            RemoveProductResponse response = new();

            RemoveProductRequestValidator validator = new(productStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to remove product due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var product = await productStore.Get(request.Moniker, cancellationToken);
            await productStore.Remove(product, cancellationToken);

            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
