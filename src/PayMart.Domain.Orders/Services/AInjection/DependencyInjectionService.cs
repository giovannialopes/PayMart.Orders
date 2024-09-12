using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Orders.AutoMapper;

namespace PayMart.Domain.Orders.Services.AInjection;

public static class DependencyInjectionService
{
    public static void AddServices(this IServiceCollection services)
    {
        AddRepositories(services);
        AutoMapper(services);
    }

    public static void AutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IOrderServices, OrderServices>();
    }


}
