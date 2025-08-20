using Microsoft.AspNetCore.Mvc;
using WebAppPortalSite.Extensions;

namespace WebAppPortalSite.ViewComponents
{
    public class UserGreetingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if ((User.Identity?.IsAuthenticated ?? false))
            {
                var session = HttpContext.GetSession();
                return View("SignedIn", session);
            }

            return View("SignedOut");
        }
    }
}
