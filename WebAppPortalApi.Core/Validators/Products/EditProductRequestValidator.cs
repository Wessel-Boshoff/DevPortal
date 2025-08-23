using FluentValidation;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Data.Stores.Products;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Products
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
