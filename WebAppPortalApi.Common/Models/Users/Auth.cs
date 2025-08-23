using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Common.Models.Users
{
    public class Auth
    {
        public string? Token { get; set; }
        public int ExpireMinutes { get; set; }
        public LoginStatus LoginStatus { get; set; }

    }
}
