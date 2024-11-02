
namespace App.Eticaret.Models.ViewModels.Cart
{
    public class CartItemListingViewModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; } = null!;
        public byte Quantity { get; set; }
    }
}
