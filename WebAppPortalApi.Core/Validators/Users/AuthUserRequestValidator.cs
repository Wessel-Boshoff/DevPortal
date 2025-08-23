using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortalApi.Core.Validators.Users
{
    public class AuthUserRequestValidator : AbstractValidator<AuthUserRequest>
    {
        public AuthUserRequestValidator()
        {
            RuleFor(c => c.Login.EmailAddress).NotEmpty();
            RuleFor(c => c.Login.EmailAddress).NotEmpty();
        }
    }
}
