using WebAppPortalSite.Common.Models;
using WebAppPortalSite.Common.Enums;

namespace WebAppPortalApiService.Requests
{
    public class BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public List<Error> Errors { get; set; } = [];
        public bool Successful { get { return ResponseCode == ResponseCode.Successful; } }

    }
}
