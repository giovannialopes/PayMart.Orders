using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.GetID;
using PayMart.Domain.Orders.Interface.Orders.Post;
using PayMart.Domain.Orders.Interface.Orders.Update;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Update;

public class UpdateOrderUseCases : IUpdateOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IGetID _getID;
    private readonly IUpdate _update;
    private readonly ICommit _commit;

    public UpdateOrderUseCases(IMapper mapper,
        IGetID getID,
        IUpdate update,
        ICommit commit)
    {
        _mapper = mapper;
        _getID = getID;
        _update = update;
        _commit = commit;
    }

    public async Task<ResponseOrder> Execute(RequestOrderUpdate request, int id)
    {
        var Order = await _getID.GetID(id);

        var response = _mapper.Map(request, Order);

        _update.Update(response);

        await _commit.Commit();

        return _mapper.Map<ResponseOrder>(response);
    }
}
