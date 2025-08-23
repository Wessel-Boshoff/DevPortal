using FluentValidation;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Data.Stores.Products;

namespace WebAppPortalSite.Core.Validators.Products
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
    {
        /// <summary>
        /// When we have something to validate put it here
        /// </summary>
        public GetProductsRequestValidator()
        {

        }
    }
}
