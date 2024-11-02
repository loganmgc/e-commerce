namespace App.Service.Models.CartItemDTOs
{
    public abstract class BaseCartItemDto
    {
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
    }
}
