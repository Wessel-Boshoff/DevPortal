using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppPortalApi.Common.Models.Users;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortalApi.Controllers;

[Authorize(Policy = "Admin")]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpDelete]
    [Route("{moniker}")]
    public async Task<IActionResult> Remove(Guid moniker, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new RemoveUserRequest() { Moniker = moniker }, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new GetUsersRequest() { }, cancellationToken));

    [HttpGet]
    [Route("{moniker}")]
    public async Task<IActionResult> Get(Guid moniker, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new GetUserRequest() { Moniker = moniker }, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> Edit(User model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new EditUserRequest() { User = model }, cancellationToken));

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Add(User model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new AddUserRequest() { User = model }, cancellationToken));

    [AllowAnonymous]
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(Login model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new AuthUserRequest() { Login = model }, cancellationToken));

    [AllowAnonymous]
    [HttpPost]
    [Route("SetPassword")]
    public async Task<IActionResult> SetPassword(Login model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new SetUserPasswordRequest() { Login = model }, cancellationToken));

}
