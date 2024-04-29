namespace McF.Service.DTO
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
