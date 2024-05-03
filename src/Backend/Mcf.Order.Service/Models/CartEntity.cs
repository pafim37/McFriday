using Mcf.Order.Service.Models.Primitives;
using System.Collections.Generic;
using Mcf.Common.Models;

namespace Mcf.Order.Service.Models
{
    public class CartEntity : Entity
    {
        public string? Place { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderEntity>? Orders { get; set; }
    }
}
