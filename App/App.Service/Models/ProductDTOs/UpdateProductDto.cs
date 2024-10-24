using System.ComponentModel.DataAnnotations;

namespace App.Service.Models.ProductDTOs
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [MaxLength(1000)]
        public string? Details { get; set; }
        [Required]
        public byte StockAmount { get; set; }
    }
}
