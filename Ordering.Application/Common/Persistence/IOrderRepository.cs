using Ordering.Domain.OrderAggregate;

namespace Ordering.Application.Common.Persistence
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetItemById(int id);
        void Create(Order item);

        void Update(Order item);
        void Delete(int id);
        void Delete(Order item);
    }
}
