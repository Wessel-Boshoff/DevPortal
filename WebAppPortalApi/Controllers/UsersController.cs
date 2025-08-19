using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppPortalApi.Common.Models.Users;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(User model, CancellationToken cancellationToken) => 
        Ok(await mediator.Send(new AddUserRequest() { User = model }, cancellationToken));

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(Login model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new AuthUserRequest() { Login = model }, cancellationToken));

}
