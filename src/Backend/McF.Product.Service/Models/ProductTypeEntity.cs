using Mcf.Common.Models;
using System.Collections.Generic;

namespace McF.Product.Service.Models
{
    public class ProductTypeEntity : Entity
    {
        public string? Name { get; set; }
        public ICollection<ProductEntity>? Products { get; } = new List<ProductEntity>();
    }
}
