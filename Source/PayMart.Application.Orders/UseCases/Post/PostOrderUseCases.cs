using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Post;

public class PostOrderUseCases : IPostOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public PostOrderUseCases(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<ResponseOrder> Execute(RequestOrder request)
    {
        var verifyOrder = await _orderRepository.VerifyOrder(request.ProductID);

        if (verifyOrder == false)
        {
            var Order = _mapper.Map<Order>(request);
            _orderRepository.AddOrder(Order);

            await _orderRepository.Commit();

            var GetID = await _orderRepository.GetByIdOrder(Order.Id);

            return _mapper.Map<ResponseOrder>(GetID);
        }

        return null;


    }
}
