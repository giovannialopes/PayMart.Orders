namespace PayMart.Domain.Orders.Request;

public class RequestOrder
{
    public DateTime Date { get; set; }
    public string Name { get; set; } = "";
    public int UserID { get; set; }
    public int ProductID { get; set; }
}

