
namespace App.Eticaret.Models.ViewModels.Cart
{
    public class CartItemListingViewModel : BaseCartItemViewModel
    {
        public int CartItemId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; } = null!;
        public decimal TotalPrice { get; set; }
    }
}
