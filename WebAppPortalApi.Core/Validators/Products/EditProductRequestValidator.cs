using FluentValidation;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Data.Stores.Products;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Validators.Products
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        public EditProductRequestValidator(IProductStore productStore, IUserStore userStore)
        {
            RuleFor(c => c.Product).SetValidator(new ProductValidator(userStore)).DependentRules(() =>
            {
                RuleFor(c => c.Product.Moniker).MustAsync(async (moniker, cancellationToken) =>
                     await productStore.Exists(moniker, cancellationToken)).WithMessage("This product does not exist");
            });
        }
    }
}
