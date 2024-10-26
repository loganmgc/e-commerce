namespace App.Service.Models.ProductDTOs
{
    public class ProductListingDto
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
        public byte? DiscountPercentage { get; set; }
        public string? ImageUrl { get; set; }
    }
}
