using Newtonsoft.Json;
using System.Text;
using WebAppPortalSite.Common.Models;
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
            return JsonConvert.DeserializeObject<PrimarySession>(Encoding.UTF8.GetString(bytes)) ?? new();
        }

        public static bool HasSession(this HttpContext context) => context.Session.Keys.Contains(primarySessionKey);

        public static void SetSession(this HttpContext context, PrimarySession session)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(session));
            context.Session.Set(primarySessionKey, bytes);
        }
    }
}
