using MediatR;
using Microsoft.AspNetCore.Mvc;

using Ordering.Application.Features.OrderFeature.Commands.CheckoutOrder;
using Ordering.Application.Features.OrderFeature.Queries.GetAllOrders;

namespace Ordering.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllOrdersQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CheckoutOrderCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
