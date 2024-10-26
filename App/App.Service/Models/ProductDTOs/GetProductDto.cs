namespace App.Service.Models.ProductDTOs
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public decimal Price { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice =>
            DiscountPercentage.HasValue ? Price - (Price * DiscountPercentage.Value / 100) : null;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SellerName { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string[] ImageUrls { get; set; } = [];
        public int? DiscountId { get; set; }
    }
}
