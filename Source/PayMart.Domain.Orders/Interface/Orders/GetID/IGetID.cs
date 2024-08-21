using PayMart.Domain.Orders.Entities;

namespace PayMart.Domain.Orders.Interface.Orders.GetID;

public interface IGetID
{
    Task<Order> GetID(int id);
}
