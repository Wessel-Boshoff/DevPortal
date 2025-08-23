using MediatR;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Core.Mappers.Errors;
using WebAppPortalSite.Core.Mappers.Logs;
using WebAppPortalSite.Core.Mappers.Products;
using WebAppPortalSite.Core.Requests.Dashboards;
using WebAppPortalSite.Core.Requests.Products;
using WebAppPortalSite.Core.Requests.Users;
using WebAppPortalSite.Core.Utilities.Auths;
using WebAppPortalSite.Core.Validators.Dashboards;
using WebAppPortalSite.Data.Stores.Products;
using WebAppPortalSite.Data.Stores.Users;
using WebAppPortalSite.Extensions;

namespace WebAppPortalSite.Core.Handlers.Dashboards
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
