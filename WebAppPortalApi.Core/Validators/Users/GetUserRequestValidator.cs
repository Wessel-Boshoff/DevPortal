using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Validators.Users
{
    public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserRequestValidator(IUserStore userStore)
        {
            RuleFor(c => c.Moniker).MustAsync(async (moniker, cancellationToken) =>
                await userStore.Exists(moniker, cancellationToken)).WithMessage("This user does not exist");
        }
    }
}
