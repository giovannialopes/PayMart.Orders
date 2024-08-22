namespace PayMart.Domain.Orders.Request;

public class RequestOrder
{
    public int ProductID { get; set; }

    public string Name { get; set; } = "";

    public int UserID {  get; set; }
}

