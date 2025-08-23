using MediatR;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Core.Mappers.Errors;
using WebAppPortalSite.Core.Mappers.Logs;
using WebAppPortalSite.Core.Mappers.Products;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Core.Utilities.Auths;
using WebAppPortalSite.Core.Validators.Products;
using WebAppPortalSite.Data.Stores.Products;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Handlers.Products
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductStore productStore;
        private readonly IUserStore userStore;

        public AddProductHandler(IProductStore productStore, IUserStore userStore)
        {
            this.productStore = productStore;
            this.userStore = userStore;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            AddProductResponse response = new();

            AddProductRequestValidator validator = new(productStore, userStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to add product due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var user = await userStore.Get(request.Product.User.Moniker, cancellationToken);
            var result = await productStore.Add(request.Product.MapAdd(user), cancellationToken);

            response.Product = result.Map(true);
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
