using FluentValidation;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Users
{
    public class GetUsersRequestValidator : AbstractValidator<GetUsersRequest>
    {
        /// <summary>
        /// When we have something to validate put it here
        /// </summary>
        public GetUsersRequestValidator()
        {

        }
    }
}
