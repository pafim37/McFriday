using McF.Process.Models.Primitives;

namespace McF.Process.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType? Type { get; set; }
        public string? Name { get; set; }
        public string? PhotoPath { get; set; }
    }
}
