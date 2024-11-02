namespace App.Service.Models.CartItemDTOs
{
    public class GetCartItemDto : BaseCartItemDto
    {
        public int CartItemId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; } = null!;
    }
}