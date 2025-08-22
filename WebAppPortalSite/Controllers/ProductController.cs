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
using WebAppPortalApi.Common.Models.Products;
using WebAppPortalApiService.Models.Products;
using WebAppPortalApiService.Services.Products;
using WebAppPortalSite.Common.Models;
using WebAppPortalSite.Mappers.Products;
using WebAppPortalSite.Common.Options;
using WebAppPortalSite.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using WebAppPortalSite.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using WebAppPortalApiService.Requests;
using WebAppPortalApiService.Services.Users;

namespace WebAppPortalSite.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly IProductService productService;
    private readonly IUserService userService;

    public ProductController(IProductService productService, IUserService userService)
    {
        this.productService = productService;
        this.userService = userService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await productService.Get(cancellationToken);
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
            //   logger.LogError(result);
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

        var result = await productService.Add(model.Map(), cancellationToken);
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
            //   logger.LogError(result);
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

        var result = await productService.Get(moniker, cancellationToken);
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
            //   logger.LogError(result);
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

        var result = await productService.Edit(model.Map(), cancellationToken);
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
            //   logger.LogError(result);
            await BindProductViewModel(model, cancellationToken);
            return View(model);
        }

        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public async Task<AjaxResult> Delete(Guid moniker, CancellationToken cancellationToken)
    {
        AjaxResult response = new();

        var result = await productService.Delete(moniker, cancellationToken);
        if (result.ResponseCode == ResponseCode.ValidationFailure)
        {
            response.Errors = result.Errors;
            response.Message = result.Message;
            response.ResponseCode = result.ResponseCode;
            return response;
        }

        if (!result.Successful)
        {
            //   logger.LogError(result);
            response.Errors.Add(new WebAppPortalApi.Common.Models.Error() { Value = "Unable to delete user." });
            response.ResponseCode = result.ResponseCode;
            return response;
        }

        response.ResponseCode = ResponseCode.Successful;
        response.Message = "Request has been processed successfully";
        return response;
    }


    private async Task<ProductViewModel> BindProductViewModel(ProductViewModel model, CancellationToken cancellationToken)
    {
        var resultUsers = await userService.Get(cancellationToken);
        if (!resultUsers.Successful)
        {
            //   logger.LogError(result);
            throw new Exception($"{resultUsers.Message} : {string.Join(", ", resultUsers.Errors)}");
        }

        var users = resultUsers.Users.Select(r => new SelectListItem
        {
            Value = r.Moniker.ToString(),
            Text = $"{r.FirstNames} {r.LastName}" ,
            Selected = r.Moniker == model.UserMoniker
        });

        model.Users = new SelectList(users, "Value", "Text");

        return model;
    }
}
