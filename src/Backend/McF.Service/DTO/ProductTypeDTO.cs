using McF.Process.Models;

namespace McF.Process.DTO
{
    public class ProductTypeDTO
    {
        public string? Name { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
