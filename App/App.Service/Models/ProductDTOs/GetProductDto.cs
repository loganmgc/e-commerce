namespace App.Service.Models.ProductDTOs
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }
    }
}
