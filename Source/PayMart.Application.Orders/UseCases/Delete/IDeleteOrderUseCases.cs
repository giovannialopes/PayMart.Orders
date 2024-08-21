using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.Delete;

public interface IDeleteOrderUseCases
{
    Task Execute(int id);
}
