namespace App.Service.Models.OrderDTOs
{
    public class AddOrderDto
    {
        public int UserId { get; set; }
        public string Address { get; set; } = null!;
    }
}
