using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Update;

public class UpdateOrderUseCases : IUpdateOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderUseCases(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<ResponseOrder> Execute(RequestOrderUpdate request, int id)
    {
        var verifyOrder = await _orderRepository.VerifyOrder(request.ProductID);

        if (verifyOrder != false)
        {
            var Order = await _orderRepository.GetByIdOrder(id);

            var response = _mapper.Map(request, Order);

            _orderRepository.UpdateOrder(response!);

            await _orderRepository.Commit();

            return _mapper.Map<ResponseOrder>(response);
        }
        return null;
    }
}
