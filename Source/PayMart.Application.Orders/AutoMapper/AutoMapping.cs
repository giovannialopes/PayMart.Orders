using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Request;
using PayMart.Domain.Orders.Response.ListOfOrder;
using PayMart.Domain.Orders.Response.Order.GetAll;
using PayMart.Domain.Orders.Response.Order.Others;

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

        CreateMap<RequestOrderUpdate, Order>()
            .ForMember(dest => dest.UserID, opt => opt.Ignore())
            .ForMember(dest => dest.ProductID, opt => opt.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Order, ResponseOrder>();
        CreateMap<Order, ResponseList>();
        CreateMap<Order, ResponseOrderGet>();
    }
}
