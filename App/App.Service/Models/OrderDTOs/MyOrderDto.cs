namespace App.Service.Models.OrderDTOs
{
    public class MyOrderDto
    {
        public string OrderCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
    }
}
