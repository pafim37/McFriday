using AutoMapper;
using Mcf.Order.Service.DTOs;
using Mcf.Order.Service.Models;

namespace Mcf.Order.Service.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            _ = CreateMap<CartDTO, Cart>()
                .ForMember(des => des.Place, src => src.MapFrom(s => s.Place))
                .ForMember(des => des.Orders, src => src.MapFrom(s => s.Orders))
                .ReverseMap();
        }
    }
}
