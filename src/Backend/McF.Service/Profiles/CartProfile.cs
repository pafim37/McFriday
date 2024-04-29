using AutoMapper;
using McF.Service.DTO;
using McF.Service.Models;

namespace McF.Service.Profiles
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
