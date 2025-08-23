using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Mappers.Products;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Core.Validators.Products;
using WebAppPortalApi.Data.Stores.Products;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Handlers.Products
{
    public class EditProductHandler : IRequestHandler<EditProductRequest, EditProductResponse>
    {
        private readonly IProductStore productStore;
        private readonly IUserStore userStore;

        public EditProductHandler(IProductStore productStore, IUserStore userStore)
        {

            this.productStore = productStore;
            this.userStore = userStore;
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            EditProductResponse response = new();

            EditProductRequestValidator validator = new(productStore, userStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to edit product due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var product = await productStore.Get(request.Product.Moniker, cancellationToken);
            var user = await userStore.Get(request.Product.User.Moniker, cancellationToken);
            product.MapEdit(request.Product, user);
            await productStore.SaveChanges(cancellationToken);

            response.Product = product.Map(true);
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
