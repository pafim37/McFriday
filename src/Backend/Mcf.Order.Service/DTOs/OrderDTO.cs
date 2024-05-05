using System.Collections.Generic;

namespace Mcf.Order.Service.DTOs
{
    public class OrderDTO
    {
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? Size { get; set; }
        public string? Number { get; set; }

        public List<string>? Extension;
    }
}
