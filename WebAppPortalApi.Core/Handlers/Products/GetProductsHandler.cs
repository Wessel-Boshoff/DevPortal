using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Mappers.Products;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Core.Validators.Products;
using WebAppPortalApi.Data.Stores.Products;

namespace WebAppPortalApi.Core.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductStore productStore;

        public GetProductsHandler(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            GetProductsResponse response = new();

            GetProductsRequestValidator validator = new();
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to get product due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var product = await productStore.Get(cancellationToken);
            response.Products = product.Map();
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
