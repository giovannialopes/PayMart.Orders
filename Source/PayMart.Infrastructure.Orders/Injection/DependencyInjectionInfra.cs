using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.Delete;
using PayMart.Domain.Orders.Interface.Orders.GetAll;
using PayMart.Domain.Orders.Interface.Orders.GetID;
using PayMart.Domain.Orders.Interface.Orders.Post;
using PayMart.Domain.Orders.Interface.Orders.Update;
using PayMart.Infrastructure.Orders.DataAcess;
using PayMart.Infrastructure.Orders.Repositories;

namespace PayMart.Infrastructure.Orders.Injection;

public static class DependencyInjectionInfra
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICommit, OrderRepository>();
        services.AddScoped<IPost, OrderRepository>();
        services.AddScoped<IGetAll, OrderRepository>();
        services.AddScoped<IGetID, OrderRepository>();
        services.AddScoped<IUpdate, OrderRepository>();
        services.AddScoped<IDelete, OrderRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<DbOrder>(config => config.UseSqlServer(connectionString));
    }
}
