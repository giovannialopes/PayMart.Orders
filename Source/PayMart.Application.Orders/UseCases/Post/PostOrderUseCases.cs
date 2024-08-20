using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.Post;

public class PostOrderUseCases : IPostOrderUseCases
{
    public Task<ResponseOrder> Execute(RequestOrder request)
    {
        throw new NotImplementedException();
    }
}
