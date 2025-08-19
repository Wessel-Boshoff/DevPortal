using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
