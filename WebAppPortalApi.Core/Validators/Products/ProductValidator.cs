using FluentValidation;
using WebAppPortalSite.Common.Models.Products;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Products
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator(IUserStore userStore)
        {
            RuleFor(c => c.User.Moniker).MustAsync(async (moniker, cancellationToken) =>
                await userStore.Exists(moniker, cancellationToken)).WithMessage("This user does not exist");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters");

            RuleFor(c => c.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(c => c.Extension)
                .NotEmpty().WithMessage("Extension is required when image was supplied")
                .When(c => !string.IsNullOrWhiteSpace(c.ImageBase64));

            RuleFor(c => c.User)
                .NotNull().WithMessage("User is required");

        }
    }
}