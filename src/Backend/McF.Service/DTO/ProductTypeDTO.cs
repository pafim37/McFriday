using System.Collections.Generic;

namespace McF.Service.DTO
{
    public class ProductTypeDTO
    {
        public string? Name { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
