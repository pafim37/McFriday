namespace McF.Service.DTO
{
    public class CartDTO
    {
        public string? Place { get; set; }

        public List<OrderDTO> Orders { get; set; }
    }
}
