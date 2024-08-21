using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.Update;

public interface IUpdateOrderUseCases
{
    Task<ResponseOrder> Execute(RequestOrder request, int id);
}
