using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.GetID;

public interface IGetOrderByID
{
    Task<ModelOrder.OrderResponse?> Execute(int id);
}
