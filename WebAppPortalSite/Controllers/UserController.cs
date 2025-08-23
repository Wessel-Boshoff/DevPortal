using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppPortalApiService.Requests;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models.Users;
using WebAppPortalSite.Extensions;
using WebAppPortalSite.Mappers.Users;

namespace WebAppPortalSite.Controllers;

[Authorize(Policy = "Admin")]
public class UserController : Controller
{
    private readonly ILogger<UserController> logger;
    private readonly IUserService userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var session = Request.HttpContext.GetSession();

        var result = await userService.Get(cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(new List<UserViewModel>());
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(new List<UserViewModel>());
        }

        return View(result.Users.Map());
    }

    public IActionResult Add()
    {
        UserViewModel model = new();
        BindUserViewModel(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            BindUserViewModel(model);
            return View(model);
        }

        var session = Request.HttpContext.GetSession();

        var result = await userService.Add(model.Map(), cancellationToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            BindUserViewModel(model);
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            BindUserViewModel(model);
            return View(model);
        }

        return RedirectToAction("Index", "User");
    }

    public async Task<IActionResult> Edit(Guid moniker, CancellationToken cancellationToken)
    {

        if (!ModelState.IsValid)
        {
            return View(new UserViewModel());
        }

        var session = Request.HttpContext.GetSession();
        var result = await userService.Get(moniker, cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(new UserViewModel());
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(new UserViewModel());
        }

        var model = result.User.MapUser();

        BindUserViewModel(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            BindUserViewModel(model);
            return View(model);
        }

        var session = Request.HttpContext.GetSession();
        var result = await userService.Edit(model.Map(), cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            BindUserViewModel(model);
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            BindUserViewModel(model);
            return View(model);
        }

        return RedirectToAction("Index", "User");
    }

    [HttpPost]
    public async Task<AjaxResult> Delete(Guid moniker, CancellationToken cancellationToken)
    {
        AjaxResult response = new();

        var session = Request.HttpContext.GetSession();
        var result = await userService.Delete(moniker, cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            response.Errors = result.Errors;
            response.Message = result.Message;
            response.ResponseCode = result.ResponseCode;
            return response;
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            response.Errors.Add(new WebAppPortalSite.Common.Models.Error() { Value = "Unable to delete user." });
            response.ResponseCode = result.ResponseCode;
            return response;
        }

        response.ResponseCode = ResponseCode.Successful;
        response.Message = "Request has been processed successfully";
        return response;
    }


    private UserViewModel BindUserViewModel(UserViewModel model)
    {
        var sourceRoles = Enum.GetValues(typeof(Role)).Cast<Role>().Where(c => c != Role.Root);
        var roles = sourceRoles
                .Select(r => new SelectListItem
                {
                    Value = r.ToString(),
                    Text = r.ToString()
                });

        model.Roles = new SelectList(roles, "Value", "Text");
        return model;
    }
}
