
namespace App.Service.Models.ProductDTOs
{
    public class GetProductsBySellerIdDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice =>
            DiscountPercentage.HasValue ? Price - (Price * DiscountPercentage.Value / 100) : null;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string? ImageUrl { get; set; }
        public int? DiscountId { get; set; }
    }
}
