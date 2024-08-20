using Microsoft.Extensions.DependencyInjection;

namespace PayMart.Application.Orders.Injection;

public static class DependencyInjectionApp
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddRepositories(services);
    }

    public static void AddRepositories(IServiceCollection services)
    {
    }


}
