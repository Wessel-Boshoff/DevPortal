using MediatR;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Core.Mappers.Errors;
using WebAppPortalSite.Core.Mappers.Logs;
using WebAppPortalSite.Core.Mappers.Products;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Core.Utilities.Auths;
using WebAppPortalSite.Core.Validators.Products;
using WebAppPortalSite.Data.Stores.Products;

namespace WebAppPortalSite.Core.Handlers.Products
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
