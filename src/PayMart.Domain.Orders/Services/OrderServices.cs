﻿using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Model;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Exceptions;


namespace PayMart.Domain.Orders.Services;

public class OrderServices(IOrderRepository orderRepository,
    IMapper mapper) : IOrderServices
{
    public async Task<ModelOrder.ListOrderResponse?> GetOrders()
    {
        var response = await orderRepository.GetOrder();
        if (response.Count != 0)
            return new ModelOrder.ListOrderResponse { Orders = mapper.Map<List<ModelOrder.OrderResponse>>(response) };

        return default;
    }

    public async Task<ModelOrder.OrderResponse?> GetOrderById(int id)
    {
        var Order = await orderRepository.GetByIdOrder(id);
        if (Order != null)
           return mapper.Map<ModelOrder.OrderResponse>(Order);

       return default;
    }

    public async Task<ModelOrder.OrderResponse?> RegisterOrder(ModelOrder.CreateOrderRequest request)
    {
        var Order = mapper.Map<Order>(request);
        Order.CreatedBy = request.UserId;

        orderRepository.AddOrder(Order);

        await orderRepository.Commit();

        var GetID = await orderRepository.GetByIdOrder(Order.Id);

        return mapper.Map<ModelOrder.OrderResponse>(GetID);
    }

    public async Task<string?> DeleteOrder(int id)
    {
        var verifyOrder = await orderRepository.GetByIdOrder(id);

        if (verifyOrder != null)
        {
            verifyOrder.DeleteBy = verifyOrder.UserId;
            verifyOrder.DeleteDate = DateTime.Now;
            verifyOrder.Status = Enums.OrderStatus.Cancelled;

            orderRepository.DeleteOrder(verifyOrder!);

            await orderRepository.Commit();

            return "Deleted";
        }
        return default;
    }
}
