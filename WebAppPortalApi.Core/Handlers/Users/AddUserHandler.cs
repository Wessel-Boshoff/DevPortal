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
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IUserStore userStore;
        private readonly IAuthUtility authUtility;

        public AddUserHandler(IUserStore userStore, IAuthUtility authUtility)
        {

            this.userStore = userStore;
            this.authUtility = authUtility;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            AddUserResponse response = new();

            AddUserRequestValidator validator = new(userStore);
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to add user due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var result = await userStore.Add(request.User.MapAdd(), cancellationToken);

            //when root user we must complete auth profile and issue token so the user can log in 
            if (request.User.Role == Role.Root)
            {
                await authUtility.CaptureAuthProfile(result, request.User.Password ?? "", cancellationToken);
                response.Auth = (await authUtility.Authenticate(request.User.EmailAddress ?? "", request.User.Password ?? "", cancellationToken)).Item1;
            }

            response.User = result.Map();
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
