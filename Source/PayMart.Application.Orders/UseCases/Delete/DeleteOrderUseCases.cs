using AutoMapper;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.Delete;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.Delete;

public class DeleteOrderUseCases : IDeleteOrderUseCases
{
    private readonly IDelete _delete;
    private readonly ICommit _commit;

    public DeleteOrderUseCases(IDelete delete,
        ICommit commit)
    {
        _delete = delete;
        _commit = commit;
    }

    public async Task Execute(int id)
    {
        await _delete.Delete(id);

        await _commit.Commit();
      
    }
}
