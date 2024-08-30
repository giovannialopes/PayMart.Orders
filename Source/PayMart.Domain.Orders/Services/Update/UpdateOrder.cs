using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.Update;

public class UpdateOrder(IOrderRepository orderRepository,
    IMapper mapper) : IUpdateOrder
{
    public async Task<ModelOrder.OrderResponse?> Execute(ModelOrder.UpdateOrderRequest request, int id)
    {
        var verifyOrder = await orderRepository.VerifyOrderExisting(request.ProductId);

        if (verifyOrder != false)
        {
            var Order = await orderRepository.GetByIdOrder(id);

            var response = mapper.Map(request, Order);
            response!.UpdatedBy = Order!.UserId;
            response.UpdatedDate = DateTime.Now;

            orderRepository.UpdateOrder(response!);

            await orderRepository.Commit();

            return mapper.Map<ModelOrder.OrderResponse>(response);
        }
        return default;
    }
}
