using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppPortalApiService.Requests;
using WebAppPortalApiService.Services.Products;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models.Products;
using WebAppPortalSite.Extensions;
using WebAppPortalSite.Mappers.Products;

namespace WebAppPortalSite.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> logger;
    private readonly IProductService productService;
    private readonly IUserService userService;

    public ProductController(ILogger<ProductController> logger, IProductService productService, IUserService userService)
    {
        this.logger = logger;
        this.productService = productService;
        this.userService = userService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var session = Request.HttpContext.GetSession();
        var result = await productService.Get(cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(new List<ProductViewModel>());
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(new List<ProductViewModel>());
        }

        return View(result.Products.Map());
    }

    public async Task<IActionResult> Add(CancellationToken cancellationToken)
    {
        ProductViewModel model = new();
        await BindProductViewModel(model, cancellationToken);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        var session = Request.HttpContext.GetSession();
        var result = await productService.Add(model.Map(), cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        return RedirectToAction("Index", "Product");
    }

    public async Task<IActionResult> Edit(Guid moniker, CancellationToken cancellationToken)
    {

        if (!ModelState.IsValid)
        {
            return View(new ProductViewModel());
        }

        var session = Request.HttpContext.GetSession();
        var result = await productService.Get(moniker, cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            return View(new ProductViewModel());
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            return View(new ProductViewModel());
        }

        var model = result.Product.MapProduct();

        await BindProductViewModel(model, cancellationToken);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        var session = Request.HttpContext.GetSession();
        var result = await productService.Edit(model.Map(), cancellationToken, session.ApiToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            foreach (var item in result.Errors.Select(c => c.Value))
            {
                ModelState.AddModelError("", item ?? "");
            }
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        if (!result.Successful)
        {
            logger.LogError(result);
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public async Task<AjaxResult> Delete(Guid moniker, CancellationToken cancellationToken)
    {
        AjaxResult response = new();

        var session = Request.HttpContext.GetSession();
        var result = await productService.Delete(moniker, cancellationToken, session.ApiToken);
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


    private async Task<ProductViewModel> BindProductViewModel(ProductViewModel model, CancellationToken cancellationToken)
    {
        var session = Request.HttpContext.GetSession();
        var resultUsers = await userService.Get(cancellationToken, session.ApiToken);
        if (!resultUsers.Successful)
        {
            //   logger.LogError(result);
            throw new Exception($"{resultUsers.Message} : {string.Join(", ", resultUsers.Errors)}");
        }

        var users = resultUsers.Users.Select(r => new SelectListItem
        {
            Value = r.Moniker.ToString(),
            Text = $"{r.FirstNames} {r.LastName}",
            Selected = r.Moniker == model.UserMoniker
        });

        model.Users = new SelectList(users, "Value", "Text");

        return model;
    }
}
