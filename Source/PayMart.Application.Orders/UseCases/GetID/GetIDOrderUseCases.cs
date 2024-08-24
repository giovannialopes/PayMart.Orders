using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Response.Order.GetAll;

namespace PayMart.Application.Orders.UseCases.GetID;

public class GetIDOrderUseCases : IGetIDOrderUseCases
{

    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetIDOrderUseCases(IOrderRepository orderRepository
        , IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<ResponseOrderGet> Execute(int id)
    {
        var Order = await _orderRepository.GetByIdOrder(id);

        return _mapper.Map<ResponseOrderGet>(Order);
    }
}
