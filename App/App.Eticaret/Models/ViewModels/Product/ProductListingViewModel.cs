namespace App.Eticaret.Models.ViewModels.Product
{
    public class ProductListingViewModel : BaseProductViewModel
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = null!;
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountedPrice => DiscountPercentage.HasValue ? Price - (Price * DiscountPercentage.Value / 100) : null;
        public string? ImageUrl { get; set; }
    }
}
