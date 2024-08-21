using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.ListOfOrder;
using PayMart.Domain.Orders.Response.Order;

namespace PayMart.Application.Orders.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestOrder, Order>();
    }

    private void EntityToResponse()
    {
        CreateMap<Order, ResponseOrder>();
        CreateMap<Order, ResponseList>();
    }
}
