using PayMart.Domain.Orders.Interface.Repositories;

namespace PayMart.Domain.Orders.Services.Delete;

public class DeleteOrder(IOrderRepository orderRepository) : IDeleteOrder
{
    public async Task<string?> Execute(int id)
    {
        var verifyOrder = await orderRepository.GetByIdOrder(id);

        if (verifyOrder != null)
        {
            verifyOrder.DeleteBy = verifyOrder.UserId;
            verifyOrder.DeleteDate = DateTime.Now;
            verifyOrder.Status = Enums.OrderStatus.Cancelled;

            orderRepository.DeleteOrder(verifyOrder!);

            await orderRepository.Commit();

            return "Delete";
        }
        return default;
    }
}
