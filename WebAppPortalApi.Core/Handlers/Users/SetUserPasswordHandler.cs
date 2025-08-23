using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Mappers.Users;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Core.Utilities.Auths;
using WebAppPortalApi.Core.Validators.Users;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Handlers.Users
{
    public class SetUserPasswordHandler : IRequestHandler<SetUserPasswordRequest, SetUserPasswordResponse>
    {
        private readonly IUserStore userStore;
        private readonly IAuthUtility authUtility;

        public SetUserPasswordHandler(IUserStore userStore, IAuthUtility authUtility)
        {

            this.userStore = userStore;
            this.authUtility = authUtility;
        }

        public async Task<SetUserPasswordResponse> Handle(SetUserPasswordRequest request, CancellationToken cancellationToken)
        {
            SetUserPasswordResponse response = new();

            SetUserPasswordValidator validator = new(userStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to set user password due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var user = await userStore.Get(request.Login.EmailAddress ?? "", cancellationToken);
            await authUtility.CaptureAuthProfile(user, request.Login.Password, cancellationToken);
            var (auth, T) = await authUtility.Authenticate(request.Login.EmailAddress, request.Login.Password, cancellationToken);
            response.Auth = auth;
            response.User = user.Map();


            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
