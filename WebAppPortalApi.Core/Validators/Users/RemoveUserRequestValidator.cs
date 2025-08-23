using FluentValidation;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Validators.Users
{
    public class RemoveUserRequestValidator : AbstractValidator<RemoveUserRequest>
    {
        public RemoveUserRequestValidator(IUserStore userStore)
        {
            RuleFor(c => c.Moniker).MustAsync(async (moniker, cancellationToken) =>
                await userStore.Exists(moniker, cancellationToken)).WithMessage("This user does not exist");
        }
    }
}
