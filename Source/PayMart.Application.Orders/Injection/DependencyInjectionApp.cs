﻿using Microsoft.Extensions.DependencyInjection;
using PayMart.Application.Orders.AutoMapper;
using PayMart.Application.Orders.UseCases.Delete;
using PayMart.Application.Orders.UseCases.GetAll;
using PayMart.Application.Orders.UseCases.GetID;
using PayMart.Application.Orders.UseCases.Post;
using PayMart.Application.Orders.UseCases.Update;

namespace PayMart.Application.Orders.Injection;

public static class DependencyInjectionApp
{
    public static void AddApplication(this IServiceCollection services)
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
        services.AddScoped<IPostOrderUseCases, PostOrderUseCases>();
        services.AddScoped<IGetAllOrderUseCases, GetAllOrderUseCases>();
        services.AddScoped<IGetIDOrderUseCases, GetIDOrderUseCases>();
        services.AddScoped<IUpdateOrderUseCases, UpdateOrderUseCases>();
        services.AddScoped<IDeleteOrderUseCases, DeleteOrderUseCases>();
    }


}
