using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Mappers.Logs;
using WebAppPortalApi.Core.Mappers.Users;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Core.Validators.Users;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Handlers.Users
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IUserStore userStore;

        public AddUserHandler(IUserStore userStore)
        {

            this.userStore = userStore;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            AddUserResponse response = new();

            AddUserRequestValidator validator = new();
            var resultValidator = validator.Validate(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to add user due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var result = await userStore.Add(request.User.MapAdd(), cancellationToken);

            response.User = result.Map();
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
