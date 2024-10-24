namespace App.Eticaret.Models.ViewModels.Product
{
    public class GetProductViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; } = null!;
    }
}
