namespace App.Service.Models.ProductDTOs
{
    public class UpdateProductDto : BaseProductDto
    {
        public int ProductId { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public int? DiscountId { get; set; }
    }
}
