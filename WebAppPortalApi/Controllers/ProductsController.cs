using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppPortalApi.Common.Models.Products;
using WebAppPortalApi.Core.Requests.Products;

namespace WebAppPortalApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpDelete]
    [Route("{moniker}")]
    public async Task<IActionResult> Remove(Guid moniker, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new RemoveProductRequest() { Moniker = moniker }, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new GetProductsRequest() { }, cancellationToken));

    [HttpGet]
    [Route("{moniker}")]
    public async Task<IActionResult> Get(Guid moniker, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new GetProductRequest() { Moniker = moniker }, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> Edit(Product model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new EditProductRequest() { Product = model }, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> Add(Product model, CancellationToken cancellationToken) =>
        Ok(await mediator.Send(new AddProductRequest() { Product = model }, cancellationToken));


}
