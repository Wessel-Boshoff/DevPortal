using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Validators.Users
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator(IUserStore userStore)
        {
            RuleFor(c => c.User).SetValidator(new UserValidator()).DependentRules(async () =>
            {
                RuleFor(c => c.User.EmailAddress).MustAsync(async (email, cancellationToken) =>
                    !await userStore.Exists(email, cancellationToken)).WithMessage("This email address is already registered.")
                    .When(c => c.User != null && !string.IsNullOrEmpty(c.User.EmailAddress));
            });
        }
    }
}
