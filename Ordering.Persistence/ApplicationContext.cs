using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
