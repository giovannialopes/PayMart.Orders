using PayMart.Domain.Orders.Enums;

namespace PayMart.Domain.Orders.Entities;

public class Order
{
    public int Id { get; set; }
    public string OrderName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public string ProductId { get; set; } = string.Empty ;


    public OrderStatus Status { get; set; } = OrderStatus.Pending; 
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeleteDate { get; set; }


    public int CreatedBy { get; set; } 
    public int UpdatedBy { get; set; } 
    public int DeleteBy { get; set; } 
}
