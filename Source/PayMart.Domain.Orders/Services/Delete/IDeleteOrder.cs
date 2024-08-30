namespace PayMart.Domain.Orders.Services.Delete;

public interface IDeleteOrder
{
    Task<string?> Execute(int id);
}
