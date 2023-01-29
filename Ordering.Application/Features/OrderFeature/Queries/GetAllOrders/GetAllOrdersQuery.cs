using MediatR;
using Ordering.Application.Common.Interfaces;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Features.OrderFeature.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>, ICacheableMediatrQuery
{
    public IEnumerable<Order> Orders { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => $"Orders";
    public TimeSpan? SlidingExpiration { get; set; }
}
