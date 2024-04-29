using AutoMapper;
using McF.Process.DTO;
using McF.Process.Models;

namespace McF.Process.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            _ = CreateMap<Product, ProductDTO>()
                .ForMember(des => des.ImageBase64, src => src.MapFrom(x => x.ImageByteArray != null ? Convert.ToBase64String(x.ImageByteArray) : null))
                .ForMember(des => des.ProductType, src => src.MapFrom(x => x.ProductType != null ? x.ProductType.Name : null))
                .ReverseMap();
        }
    }
}
