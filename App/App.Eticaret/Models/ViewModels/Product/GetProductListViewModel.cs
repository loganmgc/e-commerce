namespace App.Eticaret.Models.ViewModels.Product
{
    public class GetProductListViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
