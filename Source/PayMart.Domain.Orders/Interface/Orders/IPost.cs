using PayMart.Domain.Orders.Entities;

namespace PayMart.Domain.Orders.Interface.Orders;

public interface IPost
{
    Task Post(Order order);
}
