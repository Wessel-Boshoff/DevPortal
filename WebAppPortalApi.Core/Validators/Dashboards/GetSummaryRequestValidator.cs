using FluentValidation;
using WebAppPortalSite.Core.Requests.Dashboards;

namespace WebAppPortalSite.Core.Validators.Dashboards
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
