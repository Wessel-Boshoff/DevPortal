using WebAppPortalApiService.Requests;
using WebAppPortalSite.Extensions;
namespace WebAppPortalSite.Extensions
{
    internal static class LoggerExtension
    {
        internal static void LogError(this ILogger logger, BaseResponse baseResponse) =>
            logger.LogError($"An error has occurred while sending request: {baseResponse.ResponseCode.ToString()} : {baseResponse.Message} : {string.Join(", ", baseResponse.Errors.Select(c => c.Value))}");

    }
}
