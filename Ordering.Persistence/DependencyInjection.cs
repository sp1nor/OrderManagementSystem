using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Common.Persistence;
using Ordering.Persistence.Repositories;

namespace Ordering.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection service)
        {
            //service.AddEntityFrameworkSqlite().AddDbContext<ApplicationContext>();
            service.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("InMem"));

            service.AddTransient<IOrderRepository, OrderRepository>();
            //IServiceCollection serviceCollection = service.AddTransient<IUnitOfWork, EFUnitOfWork>();
            return service;
        }
    }
}
