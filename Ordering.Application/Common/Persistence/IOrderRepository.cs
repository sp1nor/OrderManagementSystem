using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Common.Persistence
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetItemById(int id);
        void Create(Order item);
        Task<Order> CreateAsync(Order entity);

        void Update(Order item);
        void Delete(int id);
        void Delete(Order item);
    }
}
