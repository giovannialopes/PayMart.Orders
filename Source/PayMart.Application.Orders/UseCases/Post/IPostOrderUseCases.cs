using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.Post;

public interface IPostOrderUseCases
{
    Task<ResponseOrder> Execute(RequestOrder request);
}
