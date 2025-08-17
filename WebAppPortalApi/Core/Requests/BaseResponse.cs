using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Common.Models;

namespace WebAppPortalApi.Core.Requests
{
    public class BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public List<Error> Errors { get; set; } = [];
        public bool Successful { get { return ResponseCode == ResponseCode.Successful; } }

    }
}
