using Mcf.Order.Service.Models.Primitives;
using System.Collections.Generic;

namespace Mcf.Order.Service.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string? Place { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderEntity>? Orders { get; set; }
    }
}
