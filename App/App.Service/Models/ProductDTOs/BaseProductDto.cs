namespace App.Service.Models.ProductDTOs
{
    public abstract class BaseProductDto
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
