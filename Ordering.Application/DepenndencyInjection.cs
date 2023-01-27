using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using FluentValidation;
using MediatR;
using Ordering.Application.Common.Behaviors;

namespace Ordering.Application
{
    public static class DepenndencyInjection
    {
        public static void AddApplication(this IServiceCollection service)
        {
            // add mediatR
            service.AddMediatR(Assembly.GetExecutingAssembly());

            // add automapper
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            // add validation
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // add cache
            service.AddDistributedMemoryCache();
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }
    }
}
