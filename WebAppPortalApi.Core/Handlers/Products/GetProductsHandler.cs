using MediatR;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Core.Mappers.Errors;
using WebAppPortalSite.Core.Mappers.Logs;
using WebAppPortalSite.Core.Mappers.Products;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Core.Utilities.Auths;
using WebAppPortalSite.Core.Validators.Products;
using WebAppPortalSite.Core.Validators.Users;
using WebAppPortalSite.Data.Stores.Products;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Handlers.Products
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
