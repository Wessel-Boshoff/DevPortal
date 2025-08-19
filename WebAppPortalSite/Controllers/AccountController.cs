using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using NuGet.Common;
using WebAppPortalApi.Common.Models.Users;
using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Models;
using WebAppPortalSite.Mappers.Users;
using WebAppPortalSite.Common.Options;
using WebAppPortalSite.Extensions;

namespace WebAppPortalSite.Controllers;

public class AccountController : Controller
{
    private readonly IUserService userService;
    private readonly JwtTokenOptions jwtTokenOptions;

    public AccountController(IUserService userService, IOptionsMonitor<JwtTokenOptions> jwtTokenOptions)
    {
        this.userService = userService;
        this.jwtTokenOptions = jwtTokenOptions.CurrentValue;
    }

    public IActionResult Login(string returnUrl = "")
    {
        SignOut();
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
                case Common.Enums.LoginStatus.Successful:
                    //All was well
                    break;
                default:
                    throw new ArgumentException($"Invalid mapping on LoginStatus. {result.Auth.LoginStatus} value was not expected.");
            }
            return View(model);
        }

        await SignInFromAuth(result.Auth);
        var returnUrl = TempData["returnUrl"]?.ToString();
        return string.IsNullOrWhiteSpace(returnUrl) ? RedirectToAction("Index", "Home") : Redirect(returnUrl);
    }

    public IActionResult Register()
    {
        SignOut();
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
            //   logger.LogError(result);
            return View(model);
        }
        await SignInFromAuth(result.Auth);
        return RedirectToActionPermanent("Index", "Home");
    }
    private async Task SignInFromAuth(Auth auth)
    {
        SignOut();
        var principal = jwtTokenOptions.ValidateToken(auth.Token ?? "");

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(principal.Claims, CookieAuthenticationDefaults.AuthenticationScheme)),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(auth.ExpireMinutes)
            });
    }

}
