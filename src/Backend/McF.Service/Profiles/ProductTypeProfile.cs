using AutoMapper;
using McF.Process.DTO;
using McF.Process.Models;

namespace McF.Process.Profiles
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
