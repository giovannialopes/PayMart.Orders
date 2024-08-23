using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.GetID;
using PayMart.Domain.Orders.Interface.Orders.Post;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.Post;

public class PostOrderUseCases : IPostOrderUseCases
{
    private readonly IMapper _mapper;
    private readonly IPost _post;
    private readonly IGetID _getID;
    private readonly ICommit _commit;

    public PostOrderUseCases(IMapper mapper,
        IPost post,
        ICommit commit,
        IGetID getID)
    {
        _mapper = mapper;
        _post = post;
        _commit = commit;
        _getID = getID;
    }

    public async Task<ResponseOrder> Execute(RequestOrder request)
    {
        var Order = _mapper.Map<Order>(request);

        await _post.Add(Order);

        await _commit.Commit();

        var GetID = await _getID.GetID(Order.Id);

        return _mapper.Map<ResponseOrder>(GetID);

    }
}
