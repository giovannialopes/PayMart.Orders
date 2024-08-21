using PayMart.Domain.Orders.Entities;

namespace PayMart.Domain.Orders.Interface.Orders.GetAll;

public interface IGetAll
{
    Task<List<Order>> GetAll();
}
