using Microsoft.EntityFrameworkCore;
using Ordering.Application.Common.Persistence;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Create(Order item)
    {
        _context.Add(item);
        Save();
    }

    public void Delete(int id)
    {
        var order = _context.Orders.FirstOrDefault(p => p.Id == id);

        _context.Orders.Remove(order);
        Save();
    }

    public void Delete(Order item)
    {
        _context.Orders.Remove(item);
        Save();
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders.ToList();
    }

    public Order GetItemById(int id)
    {
        var order = _context.Orders.FirstOrDefault(p => p.Id == id);

        return order;
    }

    public void Update(Order item)
    {
        var order = _context.Orders.FirstOrDefault(p => p.Id == item.Id);
        order.Date = item.Date;
        Save();
    }

    public async Task<Order> CreateAsync(Order entity)
    {
        _context.Set<Order>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
