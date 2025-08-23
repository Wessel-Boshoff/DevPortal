using FluentValidation;
using WebAppPortalApi.Core.Requests.Dashboards;

namespace WebAppPortalApi.Core.Validators.Dashboards
{
    public class GetSummaryRequestValidator : AbstractValidator<GetSummaryRequest>
    {
        /// <summary>
        /// When we have something to validate put it here
        /// </summary>
        public GetSummaryRequestValidator()
        {

        }
    }
}
