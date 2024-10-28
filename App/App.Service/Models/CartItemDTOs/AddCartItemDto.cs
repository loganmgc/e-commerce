namespace App.Service.Models.CartItemDTOs
{
    public class AddCartItemDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
    }
}
