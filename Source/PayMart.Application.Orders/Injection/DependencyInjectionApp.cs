using Microsoft.Extensions.DependencyInjection;
using PayMart.Application.Orders.UseCases.Post;

namespace PayMart.Application.Orders.Injection;

public static class DependencyInjectionApp
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddRepositories(services);
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostOrderUseCases, PostOrderUseCases>();
    }


}
