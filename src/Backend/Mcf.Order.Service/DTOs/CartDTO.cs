using System.Collections.Generic;

namespace Mcf.Order.Service.DTOs
{
    public class CartDTO
    {
        public string? Place { get; set; }

        public List<OrderDTO> Orders { get; set; }
    }
}
