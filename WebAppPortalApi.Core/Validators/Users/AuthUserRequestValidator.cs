using FluentValidation;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Users
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
