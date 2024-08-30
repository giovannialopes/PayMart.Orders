using PayMart.Domain.Orders.Enums;
using System.Text.Json.Serialization;

namespace PayMart.Domain.Orders.Model;

public class ModelOrder
{
    public class CreateOrderRequest
    {
        public string OrderName { get; set; } = string.Empty;
        public int ProductId { get; set; }

        [JsonIgnore]
        public OrderStatus Status { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }

    public class UpdateOrderRequest
    {      
        public string OrderName { get; set; } = string.Empty;
        public int ProductId { get; set; }

        [JsonIgnore]
        public OrderStatus Status { get; set; }
    }

    public class OrderResponse
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class ListOrderResponse
    {
        public List<OrderResponse> Orders { get; set; } = [];
    }

}
