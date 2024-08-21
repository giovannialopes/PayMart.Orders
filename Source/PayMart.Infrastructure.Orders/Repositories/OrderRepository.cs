using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.GetAll;
using PayMart.Domain.Orders.Interface.Orders.GetID;
using PayMart.Domain.Orders.Interface.Orders.Post;
using PayMart.Infrastructure.Orders.DataAcess;

namespace PayMart.Infrastructure.Orders.Repositories;

public class OrderRepository :
    ICommit,
    IPost,
    IGetAll,
    IGetID
{
    private readonly DbOrder _dbOrder;
    public OrderRepository(DbOrder dbOrder)
    {
        _dbOrder = dbOrder;
    }

    public async Task Commit() => await _dbOrder.SaveChangesAsync();

    public async Task<List<Order>> GetAll() => await _dbOrder.Tb_Order.AsNoTracking().ToListAsync();

    public async Task<Order?> GetID(int id) => await _dbOrder.Tb_Order.AsNoTracking().FirstOrDefaultAsync(config => config.Id == id);


    public async Task Post(Order order) => await _dbOrder.Tb_Order.AddAsync(order); 

}
