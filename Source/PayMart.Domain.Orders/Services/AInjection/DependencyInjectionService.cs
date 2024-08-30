using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Orders.AutoMapper;
using PayMart.Domain.Orders.Services.Delete;
using PayMart.Domain.Orders.Services.GetAll;
using PayMart.Domain.Orders.Services.GetID;
using PayMart.Domain.Orders.Services.Post;
using PayMart.Domain.Orders.Services.Update;

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
        services.AddScoped<IRegisterOrder, RegisterOrder>();
        services.AddScoped<IGetAllOrder, GetAllOrder>();
        services.AddScoped<IGetOrderByID, GetOrderByID>();
        services.AddScoped<IUpdateOrder, UpdateOrder>();
        services.AddScoped<IDeleteOrder, DeleteOrder>();
    }


}
