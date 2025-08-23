using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Mappers.Products;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Core.Validators.Products;
using WebAppPortalApi.Data.Stores.Products;

namespace WebAppPortalApi.Core.Handlers.Products
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IProductStore productStore;

        public GetProductHandler(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            GetProductResponse response = new();

            GetProductRequestValidator validator = new(productStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to get product due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var product = await productStore.Get(request.Moniker, cancellationToken);
            response.Product = product.Map(true);
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
