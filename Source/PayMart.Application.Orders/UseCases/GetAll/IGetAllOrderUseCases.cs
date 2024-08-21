using PayMart.Domain.Orders.Response.ListOfOrder;

namespace PayMart.Application.Orders.UseCases.GetAll;

public interface IGetAllOrderUseCases
{
    Task<ResponseList> Execute();
}
