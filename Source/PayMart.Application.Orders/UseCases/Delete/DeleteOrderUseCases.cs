using PayMart.Domain.Orders.Interface.Repositories;

namespace PayMart.Application.Orders.UseCases.Delete;

public class DeleteOrderUseCases : IDeleteOrderUseCases
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderUseCases(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }


    public async Task Execute(int id)
    {
        var getID = await _orderRepository.GetByIdOrder(id);

        _orderRepository.DeleteOrder(getID);

        await _orderRepository.Commit();

    }
}
