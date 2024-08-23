﻿using AutoMapper;
using PayMart.Domain.Orders.Interface.Database;
using PayMart.Domain.Orders.Interface.Orders.GetID;
using PayMart.Domain.Orders.Response.Order.GetAll;
using PayMart.Domain.Orders.Response.Order.Others;

namespace PayMart.Application.Orders.UseCases.GetID;

public class GetIDOrderUseCases : IGetIDOrderUseCases
{

    private readonly IMapper _mapper;
    private readonly IGetID _getID;

    public GetIDOrderUseCases(IMapper mapper,
        IGetID getID)
    {
        _mapper = mapper;
        _getID = getID;
    }

    public async Task<ResponseOrderGet> Execute(int id)
    {
        var Order = await _getID.GetID(id);

        return _mapper.Map<ResponseOrderGet>(Order);
    }
}
