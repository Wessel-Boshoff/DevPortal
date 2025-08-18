using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortalApi.Core.Validators.Users
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(c => c.User).SetValidator(new UserValidator());
        }    
    }
}
