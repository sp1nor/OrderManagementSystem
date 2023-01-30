using Ordering.Domain.Common.Models;

namespace Ordering.Domain.AggregatesModel.OrderAggregate.Entities
{
    public class OrderItem : Entity
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public int OrderId { get; set; }
    }
}
