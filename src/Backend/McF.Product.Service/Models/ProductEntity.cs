using System.ComponentModel.DataAnnotations.Schema;
using Mcf.Common.Models;

namespace McF.Product.Service.Models
{
    public class ProductEntity : Entity
    {
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductTypeEntity? ProductType { get; set; }
        public string? Name { get; set; }
        public byte[]? ImageByteArray { get; set; }
    }
}
