using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using WebAppPortalApiService.Extensions;
using WebAppPortalSite.Common.Models;
using WebAppPortalSite.Common.Options;
namespace WebAppPortalSite.Extensions
{
    public static class SessionExtensions
    {
        private const string primarySessionKey = "PrimarySession";

        public static PrimarySession GetSession(this HttpContext context)
        {
            if (!context.Session.Keys.Contains(primarySessionKey))
            {
                return new PrimarySession();
            }

            var bytes = context.Session.Get(primarySessionKey);
            return JsonConvert.DeserializeObject<PrimarySession>(Encoding.UTF8.GetString(bytes)) ?? new ();
        }

        public static bool HasSession(this HttpContext context) => context.Session.Keys.Contains(primarySessionKey);

        public static void SetSession(this HttpContext context,  PrimarySession session)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(session));
            context.Session.Set(primarySessionKey, bytes);
        }
    }
}
