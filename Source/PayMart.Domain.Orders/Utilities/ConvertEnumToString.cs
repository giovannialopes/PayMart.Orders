using PayMart.Domain.Orders.Enums;

namespace PayMart.Domain.Orders.Utilities;

public static class ConvertEnumToString
{
    public static string Convert(this OrderStatus order)
    {
        return order switch
        {
            OrderStatus.Pending => "Processando",
            OrderStatus.Cancelled => "Cancelado",
            OrderStatus.Completed => "Concluído",
            _ => ""
        };
    }
}
