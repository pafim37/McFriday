using Mcf.Common.Models;
using System.Collections.Generic;

namespace Mcf.Order.Service.Models
{
    public class OrderEntity : Entity
    {
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? Size { get; set; }
        public int Number { get; set; }
        public List<string>? Extensions { get; set; }
    }
}
