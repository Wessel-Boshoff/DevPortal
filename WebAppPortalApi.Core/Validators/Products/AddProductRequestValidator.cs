using FluentValidation;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Data.Stores.Products;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Validators.Products
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator(IProductStore productStore, IUserStore userStore)
        {
            RuleFor(c => c.Product).SetValidator(new ProductValidator(userStore));
        }
    }
}
