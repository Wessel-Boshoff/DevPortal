using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Common.Models
{
    public class Error
    {
        public string? Value { get; set; }
        public ErrorCode Code { get; set; }

    }
}
