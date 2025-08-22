using FluentValidation;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Data.Stores.Products;

namespace WebAppPortalApi.Core.Validators.Products
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
