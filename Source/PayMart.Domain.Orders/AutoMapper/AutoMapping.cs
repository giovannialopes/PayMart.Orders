using AutoMapper;
using PayMart.Domain.Orders.Entities;
using PayMart.Domain.Orders.Model;

namespace PayMart.Domain.Orders.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
        StringToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<ModelOrder.CreateOrderRequest, Order>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)) 
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) 
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
    }

    private void EntityToResponse()
    {
        CreateMap<Order, ModelOrder.OrderResponse>();
        CreateMap<Order, ModelOrder.ListOrderResponse>();
    }

    private void StringToResponse()
    {
        CreateMap<string, ModelOrder.OrderResponse>();
        CreateMap<string, ModelOrder.ListOrderResponse>();
    }
}
