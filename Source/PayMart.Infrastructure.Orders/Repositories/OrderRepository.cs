using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Infrastructure.Orders.DataAcess;

namespace PayMart.Infrastructure.Orders.Repositories;

public class OrderRepository : IOrderRepository

{
    private readonly DbOrder _dbOrder;
    public OrderRepository(DbOrder dbOrder)
    {
        _dbOrder = dbOrder;
    }

    public Task Commit() => _dbOrder.SaveChangesAsync();

    public async Task<List<Order>> GetOrder() => await _dbOrder.Tb_Order.AsNoTracking().Where(config => config.Status == Domain.Orders.Enums.OrderStatus.Pending && config.DeleteBy == 0).ToListAsync();

    public async Task<Order?> GetByIdOrder(int id) => await _dbOrder.Tb_Order.AsNoTracking().FirstOrDefaultAsync(config => config.Id == id && config.DeleteBy == 0);

    public async Task<bool?> VerifyOrderExisting(int productId) => await _dbOrder.Tb_Order.AsNoTracking().AnyAsync(config => config.ProductId == productId);

    public void AddOrder(Order order) => _dbOrder.Tb_Order.AddAsync(order);

    public void UpdateOrder(Order order) => _dbOrder.Tb_Order.Update(order);

    public void DeleteOrder(Order order) => _dbOrder.Tb_Order.Update(order);


}
