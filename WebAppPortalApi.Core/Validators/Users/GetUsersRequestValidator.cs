using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortalApi.Core.Validators.Users
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
