
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Domain.Orders.Response.ListOfOrder;

public class ResponseList
{
    public List<ResponseOrder> Orders { get; set; } = [];
}
