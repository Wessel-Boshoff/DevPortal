using MediatR;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Core.Mappers.Errors;
using WebAppPortalSite.Core.Mappers.Logs;
using WebAppPortalSite.Core.Mappers.Users;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Core.Utilities.Auths;
using WebAppPortalSite.Core.Validators.Users;
using WebAppPortalSite.Data.Stores.Users;

namespace WebAppPortalSite.Core.Handlers.Users
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IUserStore userStore;

        public RemoveUserHandler(IUserStore userStore)
        {

            this.userStore = userStore;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            RemoveUserResponse response = new();

            RemoveUserRequestValidator validator = new(userStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to remove user due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var user = await userStore.Get(request.Moniker, cancellationToken);
            await userStore.Remove(user,cancellationToken);

            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
