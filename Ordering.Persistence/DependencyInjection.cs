using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Common.Persistence;
using Ordering.Persistence.Repositories;

namespace Ordering.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection service, 
        IConfiguration configuration)
    {
        //for Development
        //service.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("InMem"));

        service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

        service.AddTransient<IOrderRepository, OrderRepository>();

        return service;
    }
}
