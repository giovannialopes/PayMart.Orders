using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Model;
using PayMart.Domain.Orders.Utilities;

namespace PayMart.Domain.Orders.Services.Post;

public class RegisterOrder(IOrderRepository orderRepository,
    IMapper mapper) : IRegisterOrder
{
    public async Task<ModelOrder.OrderResponse?> Execute(ModelOrder.CreateOrderRequest request)
    {
        var Order = mapper.Map<Order>(request);
        Order.CreatedBy = request.UserId;
       
        orderRepository.AddOrder(Order);

        await orderRepository.Commit();

        var GetID = await orderRepository.GetByIdOrder(Order.Id);

        return mapper.Map<ModelOrder.OrderResponse>(GetID);

    }
}
