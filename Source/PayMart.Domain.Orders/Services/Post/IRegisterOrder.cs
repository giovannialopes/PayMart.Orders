using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.Post;

public interface IRegisterOrder
{
    Task<ModelOrder.OrderResponse?> Execute(ModelOrder.CreateOrderRequest request);
}
