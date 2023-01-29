using AutoMapper;
using Ordering.Application.Features.OrderFeature.Commands.CheckoutOrder;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
    }
}
