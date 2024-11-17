namespace App.Service.Models.OrderDTOs
{
    public class OrderDetailsDto
    {
        public string OrderCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDetailsDto> Items { get; set; } = null!;
    }
}
