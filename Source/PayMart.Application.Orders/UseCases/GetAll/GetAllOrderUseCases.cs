using AutoMapper;
using PayMart.Domain.Orders.Interface.Repositories;
using PayMart.Domain.Orders.Response.ListOfOrder;
using PayMart.Domain.Orders.Response.Order.GetAll;

namespace PayMart.Application.Orders.UseCases.GetAll;

public class GetAllOrderUseCases : IGetAllOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetAllOrderUseCases(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<ResponseList> Execute()
    {
        var response = await _orderRepository.GetOrder();

        return new ResponseList
        {           
            Orders = _mapper.Map<List<ResponseOrderGet>>(response)
        };
    }
}
