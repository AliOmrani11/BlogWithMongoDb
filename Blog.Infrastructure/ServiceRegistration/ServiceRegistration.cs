using Blog.Application.UnitOfWork;
using Blog.Infrastructure.UnitofWork;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}