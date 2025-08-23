using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppPortalApi.Core.Requests.Dashboards;

namespace WebAppPortalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DashboardsController : ControllerBase
{
    private readonly IMediator mediator;

    public DashboardsController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new GetSummaryRequest() { }, cancellationToken));


}
