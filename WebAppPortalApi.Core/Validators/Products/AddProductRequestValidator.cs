using FluentValidation;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Data.Stores.Products;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Products
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator(IProductStore productStore, IUserStore userStore)
        {
            RuleFor(c => c.Product).SetValidator(new ProductValidator(userStore));
        }    
    }
}
