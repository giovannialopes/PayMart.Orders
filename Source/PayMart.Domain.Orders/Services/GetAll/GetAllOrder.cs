using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.GetAll;

public class GetAllOrder(IOrderRepository orderRepository,
    IMapper mapper) : IGetAllOrder
{
    public async Task<ModelOrder.ListOrderResponse?> Execute()
    {
        var response = await orderRepository.GetOrder();
        if (response.Count != 0)
            return new ModelOrder.ListOrderResponse { Orders = mapper.Map<List<ModelOrder.OrderResponse>>(response) };

        return default;
    }
}
