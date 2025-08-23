using MediatR;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Extensions;
using WebAppPortalApi.Core.Mappers.Errors;
using WebAppPortalApi.Core.Requests.Dashboards;
using WebAppPortalApi.Core.Validators.Dashboards;
using WebAppPortalApi.Data.Stores.Users;

namespace WebAppPortalApi.Core.Handlers.Dashboards
{
    public class GetSummaryHandler : IRequestHandler<GetSummaryRequest, GetSummaryResponse>
    {
        private readonly IUserStore userStore;

        public GetSummaryHandler(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        public async Task<GetSummaryResponse> Handle(GetSummaryRequest request, CancellationToken cancellationToken)
        {
            GetSummaryResponse response = new();

            GetSummaryRequestValidator validator = new();
            var resultValidator = await validator.ValidateAsync(request);
            if (!resultValidator.IsValid)
            {
                response.Errors.AddRange(resultValidator.Errors.Map());
                response.Message = "Unable to get summary due to validation failure";
                response.ResponseCode = ResponseCode.ValidationFailure;
                return response;
            }

            var users = await userStore.Get(cancellationToken);
            response.Summary = users.CalculateSummary();
            response.Message = "Request was processed successfully";
            response.ResponseCode = ResponseCode.Successful;
            return response;
        }
    }
}
