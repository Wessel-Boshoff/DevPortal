using FluentValidation;
using WebAppPortalSite.Common.Models.Users;
using WebAppPortalSite.Core.Requests.Users;

namespace WebAppPortalSite.Core.Validators.Users
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.EmailAddress).EmailAddress();
            RuleFor(c => c.FirstNames).NotEmpty().MinimumLength(2).MaximumLength(300);
            RuleFor(c => c.LastName).NotEmpty().MinimumLength(2).MaximumLength(300);

        }
    }
}