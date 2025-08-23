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
    public class AuthUserHandler : IRequestHandler<AuthUserRequest, AuthUserResponse>
    {
        private readonly IUserStore userStore;
        private readonly IAuthUtility authUtility;

        public AuthUserHandler(IUserStore userStore, IAuthUtility authUtility)
        {

            this.userStore = userStore;
            this.authUtility = authUtility;
        }

        public async Task<AuthUserResponse> Handle(AuthUserRequest request, CancellationToken cancellationToken)
        {
            AuthUserResponse response = new();

            AuthUserRequestValidator validator = new();
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to login user due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var (auth, user) = await authUtility.Authenticate(request.Login.EmailAddress ?? "", request.Login.Password ?? "", cancellationToken);
            response.Auth = auth;
            response.User = user.Map();

            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
