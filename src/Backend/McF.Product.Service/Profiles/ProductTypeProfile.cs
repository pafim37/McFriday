using AutoMapper;
using McF.Product.Service.DTO;
using McF.Product.Service.Models;

namespace McF.Product.Service.Profiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            _ = CreateMap<ProductTypeEntity, ProductTypeDTO>()
                .ReverseMap();
        }
    }
}
