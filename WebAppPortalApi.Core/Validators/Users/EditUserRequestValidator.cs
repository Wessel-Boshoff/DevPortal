using FluentValidation;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Users
{
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator(IUserStore userStore)
        {
            RuleFor(c => c.User).SetValidator(new UserValidator()).DependentRules(() =>
            {
                RuleFor(c => c.User.Moniker).MustAsync(async (moniker, cancellationToken) =>
                     await userStore.Exists(moniker, cancellationToken)).WithMessage("This user does not exist");
            }).DependentRules(() =>
            {
                RuleFor(c => c.User).MustAsync(async (c, cancellationToken) =>
                {
                    if (await userStore.Exists(c.EmailAddress ?? "", cancellationToken))
                    {
                        var emailUser = await userStore.Get(c.EmailAddress, cancellationToken);
                        return emailUser.Moniker == c.Moniker;
                    }

                    return true;
                }).WithMessage("This email is already in use by another account");
            });
        }
    }
}
