namespace PayMart.Domain.Orders.Interface.Database;

public interface ICommit
{
    Task Commit();
}
