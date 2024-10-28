namespace App.Service.Models.CartItemDTOs
{
    public class GetCartItemDto
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; } = null!;
        public byte Quantity { get; set; }
    }
}