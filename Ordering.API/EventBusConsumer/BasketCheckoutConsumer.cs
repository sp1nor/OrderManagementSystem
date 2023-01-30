using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.OrderFeature.Commands.CheckoutOrder;

namespace Ordering.API.EventBusConsumer;

public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BasketCheckoutConsumer> _logger;

    public BasketCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        var command = new CheckoutOrderCommand();
        command.UserName = context.Message.UserName;
        command.TotalPrice = context.Message.TotalPrice;
        command.AddressLine = context.Message.AddressLine;
        command.EmailAddress = context.Message.EmailAddress;
        command.Country = context.Message.Country;
        command.State = context.Message.State;
        command.FirstName = context.Message.FirstName;
        command.LastName = context.Message.LastName;
        command.ZipCode = context.Message.ZipCode;

        var result = await _mediator.Send(command);

        _logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
    }
}
