
namespace McF.Service.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? Size { get; set; }
        public int Number {  get; set; }
        public List<string>? Extensions { get; set; }
    }
}
