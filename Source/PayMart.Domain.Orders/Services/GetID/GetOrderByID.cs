using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.GetID;

public class GetOrderByID(IOrderRepository orderRepository
        , IMapper mapper) : IGetOrderByID
{
    public async Task<ModelOrder.OrderResponse?> Execute(int id)
    {
        var Order = await orderRepository.GetByIdOrder(id);
        if (Order != null)
              return mapper.Map<ModelOrder.OrderResponse>(Order);

        return default;
    }
}
