namespace PayMart.Domain.Orders.Response.Order;

public class ResponseOrder
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string Name { get; set; } = "";
}
