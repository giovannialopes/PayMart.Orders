using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.Update;

public interface IUpdateOrder
{
    Task<ModelOrder.OrderResponse?> Execute(ModelOrder.UpdateOrderRequest request, int id);
}
