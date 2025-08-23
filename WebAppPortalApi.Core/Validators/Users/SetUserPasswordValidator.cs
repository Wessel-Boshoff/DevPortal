using FluentValidation;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Validators.Users
{
    public class SetUserPasswordValidator : AbstractValidator<SetUserPasswordRequest>
    {
        public SetUserPasswordValidator(IUserStore userStore)
        {
            RuleFor(c => c.Login.EmailAddress)
                .MustAsync(async (c, cancellationToken) =>
                    await userStore.Exists(c, cancellationToken))
                .WithMessage("This user does not exist")
                .DependentRules(() =>
                {
                    RuleFor(c => c.Login.EmailAddress)
                        .MustAsync(async (c, cancellationToken) =>
                            (await userStore.Get(c, cancellationToken)).RegistrationStatus == Common.Enums.RegistrationStatus.NeedPassword)
                        .WithMessage("This user does not need a password");
                });

        }
    }
}
