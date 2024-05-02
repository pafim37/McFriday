using System.Collections.Generic;

namespace McF.Service.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; } = new List<Product>();
    }
}
