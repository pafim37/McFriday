using Microsoft.Extensions.Hosting;

namespace McF.Process.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; } = new List<Product>();
    }
}
