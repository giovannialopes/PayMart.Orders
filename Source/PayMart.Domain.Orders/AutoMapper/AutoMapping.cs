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
    }

    private void RequestToEntity()
    {
        CreateMap<ModelOrder.CreateOrderRequest, Order>();

        CreateMap<ModelOrder.UpdateOrderRequest, Order>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.ProductId, opt => opt.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Order, ModelOrder.OrderResponse>();
        CreateMap<Order, ModelOrder.ListOrderResponse>();
    }
}
