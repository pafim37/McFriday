using AutoMapper;
using Mcf.Order.Service.DTOs;
using Mcf.Order.Service.Models;

namespace Mcf.Order.Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            _ = CreateMap<OrderDTO, OrderEntity>()
            .ForMember(des => des.Number, src => src.MapFrom(s => s.Number != null ? int.Parse(s.Number) : 0));
        }
    }
}
