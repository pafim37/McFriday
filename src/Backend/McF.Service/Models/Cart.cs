using McF.Service.Models.Primitives;

namespace McF.Service.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string? Place { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public List<Order> Orders { get; set; }

    }
}
