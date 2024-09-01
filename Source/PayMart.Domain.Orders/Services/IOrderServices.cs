using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services;

public interface IOrderServices
{
    Task<ModelOrder.ListOrderResponse?> GetOrders();
    Task<ModelOrder.OrderResponse?> GetOrderById(int id);
    Task<ModelOrder.OrderResponse?> RegisterOrder(ModelOrder.CreateOrderRequest request);
    Task<string?> DeleteOrder(int id);
}
