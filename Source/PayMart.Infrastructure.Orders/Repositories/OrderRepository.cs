using PayMart.Domain.Orders.Interface.Database;
using PayMart.Infrastructure.Orders.DataAcess;

namespace PayMart.Infrastructure.Orders.Repositories;

public class OrderRepository :
    ICommit
{
    private readonly DbOrder _dbOrder;
    public OrderRepository(DbOrder dbOrder)
    {
        _dbOrder = dbOrder;
    }

    public Task Commit()
    {
        throw new NotImplementedException();
    }
}
