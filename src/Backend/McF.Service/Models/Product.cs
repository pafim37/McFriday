using System.ComponentModel.DataAnnotations.Schema;

namespace McF.Process.Models
{
    public class Product
    {
        public int Id { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public string? Name { get; set; }
        public byte[]? ImageByteArray { get; set; }
    }
}
