using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Post;

public interface IPostOrderUseCases
{
    Task<ResponseOrder> Execute(RequestOrder request);
}
