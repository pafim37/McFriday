using AutoMapper;
using McF.Product.Service.DTO;
using System;

namespace McF.Product.Service.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            _ = CreateMap<Models.ProductEntity, ProductDTO>()
                .ForMember(des => des.ImageBase64, src => src.MapFrom(x => x.ImageByteArray != null ? Convert.ToBase64String(x.ImageByteArray) : null))
                .ForMember(des => des.ProductType, src => src.MapFrom(x => x.ProductType != null ? x.ProductType.Name : null))
                .ReverseMap();
        }
    }
}
