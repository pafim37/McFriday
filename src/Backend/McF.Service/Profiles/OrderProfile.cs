using AutoMapper;
using McF.Service.DTO;
using McF.Service.Models;

namespace McF.Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            _ = CreateMap<OrderDTO, Order>()
            .ForMember(des => des.Number, src => src.MapFrom(s => s.Number != null ? int.Parse(s.Number) : 0));
        }
    }
}
