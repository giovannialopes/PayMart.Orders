using PayMart.Domain.Orders.Enums;
using System.Text.Json.Serialization;

namespace PayMart.Domain.Orders.Model;

public class ModelOrder
{
    public class CreateOrderRequest
    {
        public List<int> ProductIds { get; set; } = new List<int>();

        [JsonIgnore]
        public OrderStatus Status { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public decimal Price { get; set; }

        [JsonIgnore]
        public string ProductId { get; set; } = string.Empty;
    }

    public class OrderResponse
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty ;
    }

    public class ListOrderResponse
    {
        public List<OrderResponse> Orders { get; set; } = [];
    }


}
