using System.Collections.Generic;

namespace McF.Product.Service.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ProductEntity>? Products { get; } = new List<ProductEntity>();
    }
}
