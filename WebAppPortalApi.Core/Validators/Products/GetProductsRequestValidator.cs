using FluentValidation;
using WebAppPortalApi.Core.Requests.Products;

namespace WebAppPortalApi.Core.Validators.Products
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
