using AutoMapper;
using McF.Service.DTO;
using McF.Service.Models;

namespace McF.Service.Profiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            _ = CreateMap<ProductType, ProductTypeDTO>()
                .ReverseMap();
        }
    }
}
