namespace App.Service.Models.ProductDTOs
{
    public class ProductListingDto : BaseProductDto
    {
        public int ProductId {  get; set; }
        public string CategoryName { get; set; } = null!;
        public byte? DiscountPercentage { get; set; }
        public string? ImageUrl { get; set; }
    }
}
