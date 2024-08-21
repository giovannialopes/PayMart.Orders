using AutoMapper;
using PayMart.Domain.Orders.Interface.Orders.GetAll;
using PayMart.Domain.Orders.Response.ListOfOrder;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.UseCases.GetAll;

public class GetAllOrderUseCases : IGetAllOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IGetAll _getAll;

    public GetAllOrderUseCases(IMapper mapper,
        IGetAll getAll)
    {
        _mapper = mapper;
        _getAll = getAll;
    }

    public async Task<ResponseList> Execute()
    {
        var response = await _getAll.GetAll();

        return new ResponseList
        {           
            Orders = _mapper.Map<List<ResponseOrder>>(response)
        };
    }
}
