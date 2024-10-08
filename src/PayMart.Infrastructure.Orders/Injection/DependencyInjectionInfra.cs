﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Repositories;
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
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICommit, OrderRepository>();

        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<DbOrder>(config => config.UseSqlServer(connectionString));
    }
}
