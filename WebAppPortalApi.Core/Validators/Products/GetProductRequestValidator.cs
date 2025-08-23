using FluentValidation;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Data.Stores.Products;

namespace WebAppPortalSite.Core.Validators.Products
{
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator(IProductStore productStore)
        {
            RuleFor(c => c.Moniker).MustAsync(async (moniker, cancellationToken) =>
                await productStore.Exists(moniker, cancellationToken)).WithMessage("This product does not exist");
        }
    }
}
