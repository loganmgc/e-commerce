
namespace App.Service.Models.ProductDTOs
{
    public class GetProductsBySellerIdDto : BaseProductDto
    {
        public int ProductId { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice =>
            DiscountPercentage.HasValue ? Price - (Price * DiscountPercentage.Value / 100) : null;
        public string CategoryName { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string? ImageUrl { get; set; }
        public int? DiscountId { get; set; }
    }
}
