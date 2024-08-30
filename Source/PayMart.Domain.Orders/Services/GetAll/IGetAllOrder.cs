using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.Services.GetAll;

public interface IGetAllOrder
{
    Task<ModelOrder.ListOrderResponse?> Execute();
}
