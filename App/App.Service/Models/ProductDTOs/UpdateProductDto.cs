namespace App.Service.Models.ProductDTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public int? DiscountId { get; set; }
    }
}
