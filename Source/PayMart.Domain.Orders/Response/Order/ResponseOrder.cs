namespace PayMart.Domain.Orders.Response.Order;

public class ResponseOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int ProductID { get; set; }
    public DateTime Date { get; set; }

    public int UserID { get; set; }

}
