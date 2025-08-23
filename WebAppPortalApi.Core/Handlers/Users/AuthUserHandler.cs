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

            var(auth, user) = await authUtility.Authenticate(request.Login.EmailAddress ?? "", request.Login.Password ?? "", cancellationToken);
            response.Auth = auth;
            response.User = user.Map();

            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
