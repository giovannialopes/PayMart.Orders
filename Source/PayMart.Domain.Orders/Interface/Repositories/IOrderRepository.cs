using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Database;

namespace PayMart.Domain.Orders.Interface.Repositories;

public interface IOrderRepository : ICommit
{
    public Task<List<Order?>> GetOrder();

    public Task<Order?> GetByIdOrder(int id);

    public Task<bool?> VerifyOrder(int productId);

    public void AddOrder(Order order);

    public void UpdateOrder(Order order);

    public void DeleteOrder(Order order);

}
