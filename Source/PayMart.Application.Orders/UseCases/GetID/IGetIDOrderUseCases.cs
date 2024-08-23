using PayMart.Domain.Orders.Response.Order.GetAll;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.GetID;

public interface IGetIDOrderUseCases
{
    Task<ResponseOrderGet> Execute(int id);
}
