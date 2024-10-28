namespace App.Eticaret.Models.ViewModels.Profile
{
    public class MyProductsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public byte StockAmount { get; set; }
        public string? ImageUrls { get; set; }
        public int? DiscountId { get; set; }
    }
}
