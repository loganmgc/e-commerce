namespace App.Eticaret.Models.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public string OrderCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
    }
}
