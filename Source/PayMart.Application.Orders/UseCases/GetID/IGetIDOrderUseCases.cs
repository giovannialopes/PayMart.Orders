using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.GetID;

public interface IGetIDOrderUseCases
{
    Task<ResponseOrder> Execute(int id);
}
