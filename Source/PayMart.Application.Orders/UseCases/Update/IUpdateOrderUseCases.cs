using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Update;

public interface IUpdateOrderUseCases
{
    Task<ResponseOrder> Execute(RequestOrderUpdate request, int id);
}
