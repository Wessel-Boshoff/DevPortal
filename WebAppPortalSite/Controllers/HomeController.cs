using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppPortalApiService.Requests;
using WebAppPortalApiService.Services.Dashboards;
using WebAppPortalApiService.Services.Users;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Models;
using WebAppPortalSite.Mappers.Dashboards;

namespace WebAppPortalSite.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDashboardService dashboardService;

    public HomeController(ILogger<HomeController> logger, IDashboardService dashboardService)
    {
        _logger = logger;
        this.dashboardService = dashboardService;
    }


    public IActionResult Index()
    {
        return View();
    }


    public async Task<AjaxResult> LoadSummary(CancellationToken cancellationToken)
    {
        AjaxResult response = new ();
        var result = await dashboardService.Get(cancellationToken);
        if (result.ResponseCode == Common.Enums.ResponseCode.ValidationFailure)
        {
            response.Errors.AddRange(result.Errors);
            response.ResponseCode = ResponseCode.ValidationFailure;
            return response;
        }

        if (!result.Successful)
        {
            //   logger.LogError(result);
            response.Message = "Unable to load due to an error";
            response.Errors.Add(new Error() {  Value = response.Message });
            response.ResponseCode = ResponseCode.Error;
            return response;
        }

        response.Data = result.Summary.MapSummary();
        response.ResponseCode = ResponseCode.Successful;
        response.Message = "Request was processed successfully.";
        return response;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
