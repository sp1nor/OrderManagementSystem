using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderAggregate;

namespace Ordering.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
