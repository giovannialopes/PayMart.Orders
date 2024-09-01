using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services;

public interface IOrderServices
{
    Task<(ModelOrder.ListOrderResponse? Response, string? Error)> GetOrders();
    Task<(ModelOrder.OrderResponse? Response, string? Error)> GetOrderById(int id);
    Task<ModelOrder.OrderResponse?> RegisterOrder(ModelOrder.CreateOrderRequest request);
    Task<string?> DeleteOrder(int id);
}
