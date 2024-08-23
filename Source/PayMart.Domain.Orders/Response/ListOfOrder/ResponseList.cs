using PayMart.Domain.Orders.Response.Order.GetAll;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Domain.Orders.Response.ListOfOrder;

public class ResponseList
{
    public List<ResponseOrderGet> Orders { get; set; } = [];
}
