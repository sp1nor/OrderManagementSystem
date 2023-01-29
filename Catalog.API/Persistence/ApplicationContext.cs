using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            CatalogContextSeed.SeedData(Products);
            this.SaveChanges();
        }
    }
}
