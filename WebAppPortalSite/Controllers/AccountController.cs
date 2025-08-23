using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Models.Users;
using WebAppPortalSite.Extensions;
using WebAppPortalSite.Mappers.Users;

namespace WebAppPortalSite.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> logger;
    private readonly IUserService userService;

    public AccountController(ILogger<AccountController> logger, IUserService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    public IActionResult AccessDenied(string returnUrl = "")
    {
        SignOutUser();
        TempData["returnUrl"] = returnUrl;
        return View();
    }

    public IActionResult Login(string returnUrl = "")
    {
        SignOutUser();
        TempData["returnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await userService.Login(model.Map(), cancellationToken);
        if (result.ResponseCode == Common.Enums.ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(model);
        }

        if (result.Auth.LoginStatus != Common.Enums.LoginStatus.Successful)
        {
            switch (result.Auth.LoginStatus)
            {
                case Common.Enums.LoginStatus.InvalidUseramePassword:
                    ModelState.AddModelError("", "Invalid username and password.");
                    break;
                case Common.Enums.LoginStatus.Locked:
                    ModelState.AddModelError("", "Profile has been locked, please wait a few minutes and try again.");
                    break;
                case Common.Enums.LoginStatus.NeedPassword:
                    ModelState.AddModelError("", "Needs a password.");
                    break;
                case Common.Enums.LoginStatus.Successful:
                    //All was well
                    break;
                default:
                    throw new ArgumentException($"Invalid mapping on LoginStatus. {result.Auth.LoginStatus} value was not expected.");
            }
            return View(model);
        }

        await SignInFromAuth(result.Auth, result.User);
        var returnUrl = TempData["returnUrl"]?.ToString();
        return string.IsNullOrWhiteSpace(returnUrl) ? RedirectToAction("Index", "Home") : Redirect(returnUrl);
    }


    public IActionResult SetPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SetPassword(SetPasswordViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await userService.SetPassword(model.Map(), cancellationToken);
        if (result.ResponseCode == Common.Enums.ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(model);
        }

        await SignInFromAuth(result.Auth, result.User);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        SignOutUser();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await userService.Add(model.Map(), cancellationToken);
        if (result.ResponseCode == Common.Enums.ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(model);
        }
        await SignInFromAuth(result.Auth, result.User);
        return RedirectToActionPermanent("Index", "Home");
    }

    public IActionResult Logout()
    {
        SignOutUser();
        return RedirectToAction("Login");
    }


    private void SignOutUser()
    {
        Request.HttpContext.Session.Clear();
        SignOut();
    }


    private async Task SignInFromAuth(Auth auth, User user)
    {
        SignOutUser();
        HttpContext.SetSession(user.Map(auth.Token ?? ""));

        var readToken = auth.Token?.ReadJWTToken();

        var claims = readToken?.Claims.ToList();

        var roleClaim = claims?.FirstOrDefault(c =>
            c.Type == "role" ||
            c.Type == "roles" ||
            c.Type == ClaimTypes.Role ||
            c.Type.EndsWith("/role"));

        if (roleClaim != null)
        {
            claims?.RemoveAll(c =>
                c.Type == "role" ||
                c.Type == "roles" ||
                c.Type == ClaimTypes.Role ||
                c.Type.EndsWith("/role"));

            claims?.Add(new Claim(ClaimTypes.Role, roleClaim.Value));
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(auth.ExpireMinutes)
            });
    }


}
