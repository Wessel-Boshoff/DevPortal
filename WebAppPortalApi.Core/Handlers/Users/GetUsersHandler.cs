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
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUserStore userStore;

        public GetUsersHandler(IUserStore userStore)
        {

            this.userStore = userStore;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            GetUsersResponse response = new();

            GetUsersRequestValidator validator = new();
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to get user due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var user = await userStore.Get(cancellationToken);
            response.Users = user.Map();
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
