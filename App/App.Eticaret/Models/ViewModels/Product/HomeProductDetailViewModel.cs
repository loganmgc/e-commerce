using App.Eticaret.Models.ViewModels.ProductComment;

namespace App.Eticaret.Models.ViewModels.Product
{
    public class HomeProductDetailViewModel : BaseProductViewModel
    {
        public int ProductId { get; set; }
        public string? Details { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice {  get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SellerName { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string[] ImageUrls { get; set; } = [];
        public GetProductCommentViewModel[] Reviews { get; set; } = [];
        public double? AverageStarCount => Reviews.Length == 0 ? null : Reviews.Average(r => r.StarCount);

    }
}
